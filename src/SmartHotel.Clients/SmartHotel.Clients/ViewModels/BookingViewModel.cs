using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
using SmartHotel.Clients.Core.Services.Hotel;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SmartHotel.Clients.Core.Models;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class BookingViewModel : ViewModelBase
    {
        private readonly IAnalyticService _analyticService;
        private readonly IHotelService _hotelService;

        private string _search;
        private IEnumerable<Models.City> _cities;
        private IEnumerable<City> ListItem;
        private IEnumerable<string> _suggestions;
        private string _suggestion;
        private City _anyItem;
        private bool _isNextEnabled;

        public BookingViewModel(
            IAnalyticService analyticService,
            IHotelService hotelService)
        {
            _analyticService = analyticService;
            _hotelService = hotelService;

            _cities = new List<Models.City>();
            _suggestions = new List<string>();
        }

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                FilterAsync(_search);
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }


        public IEnumerable<City> Touchpoints {

            get { return ListItem; }
            set {
                ListItem = value;
                OnPropertyChanged();

            }
        }

        public string Suggestion
        {
            get { return _suggestion; }
            set
            {
                _suggestion = value;
                
                IsNextEnabled = string.IsNullOrEmpty(_suggestion) ? false : true;

                var dismissKeyboardService = DependencyService.Get<IDismissKeyboardService>();
                dismissKeyboardService.DismissKeyboard();

                OnPropertyChanged();
            }
        }

        public City Item {
            get { return _anyItem; }
            set{
                _anyItem = value;
            }
        }
        public bool IsNextEnabled
        {
            get { return _isNextEnabled; }
            set
            {
                _isNextEnabled = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand => new AsyncCommand(NextAsync);

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                _cities = await _hotelService.GetCitiesAsync();
                Touchpoints = TouchPointMaker();
                Suggestions = new List<string>(_cities.Select(c => c.ToString()));
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[Booking Where Step] Error retrieving data: {httpEx}");

                if (!string.IsNullOrEmpty(httpEx.Message))
                {
                    await DialogService.ShowAlertAsync(
                        string.Format(Resources.HttpRequestExceptionMessage, httpEx.Message),
                        Resources.HttpRequestExceptionTitle,
                        Resources.DialogOk);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking Where Step] Error: {ex}");

                await DialogService.ShowAlertAsync(
                    Resources.ExceptionMessage,
                    Resources.ExceptionTitle,
                    Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public IEnumerable<City> TouchPointMaker()
        {

            List<City> Touchpoints = new List<City>();
            for (int i = 0; i < 10; i++)
            {
                City newTp = new City();
                newTp.Name = "Account #" + i;
                newTp.Country = "Place #" + i;
                newTp.Crop = "Corn";
                newTp.RadL = "R";
                newTp.SAP = "#1024098";
                newTp.ProgramCount = i+3;
                newTp.TotalCount = (i + 3) * 17;
                Touchpoints.Add(newTp);
            }
            return Touchpoints;
        }

        private async void FilterAsync(string search)
        {
            try
            {
                IsBusy = true;

                Suggestions = new List<string>(
                    _cities.Select(c => c.ToString())
                           .Where(c => c.ToLowerInvariant().Contains(search.ToLowerInvariant())));

                _analyticService.TrackEvent("Filter", new Dictionary<string, string>
                {
                    { "Search", search }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Booking] Error: {ex}");
                await DialogService.ShowAlertAsync(Resources.ExceptionMessage, Resources.ExceptionTitle, Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task NextAsync()
        {
            var city = _cities.FirstOrDefault(c => c.ToString().Equals(Suggestion));

            if (city != null)
            {
                await NavigationService.NavigateToAsync<BookingCalendarViewModel>(city);
            }
        }
    }
}