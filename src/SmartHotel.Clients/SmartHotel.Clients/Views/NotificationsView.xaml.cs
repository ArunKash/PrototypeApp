using SmartHotel.Clients.Core.Helpers;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using SmartHotel.Clients.Core.Controls;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Views
{
    public partial class NotificationsView : ContentPage
    {
        private Microcharts.Chart _temperatureChart;
        private Microcharts.Chart _greenChart;

        public NotificationsView()
        {
            InitializeComponent();
        }


        public Microcharts.Chart TemperatureChart
        {
            get { return _temperatureChart; }

            set
            {
                _temperatureChart = value;
                OnPropertyChanged();
            }
        }

        public Microcharts.Chart GreenChart
        {
            get { return _greenChart; }

            set
            {
                _greenChart = value;
                OnPropertyChanged();
            }
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            StatusBarHelper.Instance.MakeTranslucentStatusBar(false);
            // TemperatureChart = await GetTemperatureChartAsync();
            //GreenChart = await GetGreenChartAsync();
        }


        public async Task<Microcharts.Chart> GetGreenChartAsync()
        {
            await Task.Delay(500);

            var data = new[]
            {
                new Microcharts.Entry(120)
                {
                        Label = "06:00",
                        ValueLabel = "120",
                        Color = SKColor.Parse("#BC4C1B"),
                },
                new Microcharts.Entry(140)
                {
                        Label = "10:00",
                        ValueLabel = "140",
                        Color = SKColor.Parse("#BC4C1B"),
                },
                new Microcharts.Entry(45)
                {
                        Label = "14:00",
                        ValueLabel = "45",
                        Color = SKColor.Parse("#0BC3B6"),
                },
                new Microcharts.Entry(100)
                {
                        Label = "18:00",
                        ValueLabel = "100",
                        Color = SKColor.Parse("#0BC3B6"),
                },
                new Microcharts.Entry(130)
                {
                        Label = "22:00",
                        ValueLabel = "130",
                        Color = SKColor.Parse("#BC4C1B"),
                },
                new Microcharts.Entry(75)
                {
                        Label = "02:00",
                        ValueLabel = "75",
                        Color = SKColor.Parse("#0BC3B6"),
                }
            };

            return new GreenChart() { Entries = data };
        }


        public async Task<Microcharts.Chart> GetTemperatureChartAsync()
        {
            await Task.Delay(500);

            var data = new[]
            {
                new Microcharts.Entry(50)
                {
                        ValueLabel = "50",
                        Color = SKColor.Parse("#104950"),
                },
                new Microcharts.Entry(72)
                {
                        ValueLabel = "76",
                        Color = SKColor.Parse("#348E94"),
                },
                new Microcharts.Entry(81)
                {
                        ValueLabel = "82",
                        Color = SKColor.Parse("#D97F55"),
                },
                new Microcharts.Entry(90)
                {
                        ValueLabel = "90",
                        Color = SKColor.Parse("#EFBCB0"),
                }
            };
            return new GreenChart() { Entries = data };
        }
    }
}