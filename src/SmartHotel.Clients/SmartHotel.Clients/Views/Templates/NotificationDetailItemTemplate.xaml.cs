using System;
using System.Windows.Input;
using SmartHotel.Clients.Core.Services.Navigation;
using SmartHotel.Clients.Core.ViewModels;
using SmartHotel.Clients.Core.ViewModels.Base;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Views.Templates
{
    public partial class NotificationDetailItemTemplate : ContentView
    {
        public static readonly BindableProperty DeleteCommandProperty =
               BindableProperty.Create(
                   "DeleteCommand",
                   typeof(ICommand),
                   typeof(NotificationDetailItemTemplate),
                   default(ICommand));

        protected readonly INavigationService NavigationService;


        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        public NotificationDetailItemTemplate()
        {
            InitializeComponent();

            NavigationService = Locator.Instance.Resolve<INavigationService>();


            var tapGesture = new TapGestureRecognizer
            {
                Command = new Command(OnDeleteTapped)
            };

            var itemTapGesture = new TapGestureRecognizer
            {
                Command = new Command(OnItemTapped)

            };
            TouchpointItem.GestureRecognizers.Add(itemTapGesture);
           

            DeleteImage.GestureRecognizers.Add(tapGesture);
            InitializeCell();
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isUwp = Device.RuntimePlatform == Device.UWP;

                    DeleteContainer.BackgroundColor = Color.FromHex("#EC0843");
                    DeleteImage.Source =  isUwp ? $"Assets/ic_paperbin.png" : $"ic_paperbin";

                    await this.TranslateTo(-this.Width, 0, 500, Easing.SinIn);

                    DeleteCommand?.Execute(BindingContext);

                    InitializeCell();
                });
            }
        }

        private ICommand moveToSummaryScreenCommand
        {


            get
            {
                return new Command(async () =>
                {
                    //push asyn to the Summary page
                    //Debug.WriteLine("it gets here!");

                    await NavigationService.NavigateToAsync<BookingViewModel>();



                    //var isUwp = Device.RuntimePlatform == Device.UWP;

                    //DeleteContainer.BackgroundColor = Color.FromHex("#EC0843");
                    //DeleteImage.Source =  isUwp ? $"Assets/ic_paperbin.png" : $"ic_paperbin";

                    //await this.TranslateTo(-this.Width, 0, 500, Easing.SinIn);

                    //DeleteCommand?.Execute(BindingContext);

                    //InitializeCell();
                });
            }

        }

        private void OnDeleteTapped()
        {
            TransitionCommand.Execute(null);
        }

        private void OnItemTapped()
        {
            moveToSummaryScreenCommand.Execute(null);
        }

        private void InitializeCell()
        {
            var isUwp = Device.RuntimePlatform == Device.UWP;

            this.TranslationX = 0;
            DeleteContainer.BackgroundColor = Color.FromHex("#F2F2F2");
            DeleteImage.Source = isUwp ? $"Assets/ic_paperbin_red.png" : $"ic_paperbin_red";
        }
        protected override void OnChildAdded(Xamarin.Forms.Element child)
        {
            base.OnChildAdded(child);

        }
    }
}