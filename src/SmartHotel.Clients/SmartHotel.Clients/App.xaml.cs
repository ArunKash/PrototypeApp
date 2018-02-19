using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Identity.Client;
using SmartHotel.Clients.Core;
using SmartHotel.Clients.Core.Services.Navigation;
using SmartHotel.Clients.Core.ViewModels;
using SmartHotel.Clients.Core.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartHotel.Clients.Core.Views;
using SmartHotel.Clients.Core.Views.Templates;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartHotel.Clients
{
    public partial class App : Application
    {
        public static PublicClientApplication AuthenticationClient { get; set; }
        private WebWrapper LoginWrapper;
        static App()
        {
            BuildDependencies();
        }
        public App()
        {
            AuthenticationClient =
                new PublicClientApplication($"{AppSettings.B2cAuthority}{AppSettings.B2cTenant}", AppSettings.B2cClientId);

            InitializeComponent();

            MessagingCenter.Subscribe<WebWrapper>(this, "ShowMainPage", (sender) =>
            {
                InitNavigation();
            });



            // MainPage = new NavigationPage(new WebWrapper("https://login.salesforce.com"));
           // if (LoginWrapper == null)
                //LoginWrapper = new WebWrapper("https://test-mon.cs95.force.com/wheat/services/oauth2/authorize?response_type=code&client_id=3MVG9XmM8CUVepGaWq.XTuUtlm9_LWviPULVvlqxitqz5BBC7O9H7V2qxf5jmcNh7Y_QWWGi32jqkoPWfF2_u&redirect_uri=https://test.salesforce.com/services/oauth2/success");
            //LoginWrapper = new WebWrapper("https://arun-zone-dev-ed.my.salesforce.com/services/oauth2/authorize?response_type=code&client_id=3MVG9ZL0ppGP5UrDhS8a_1kOJZ5ihoBL70D8.rWXY2sIkEwjBOA8MDB10od0aOdu_jhzcLqw2F3t6nv0M2pWZ&redirect_uri=https://arun-zone-dev-ed.my.salesforce.com/auth/success");
            //else
                //LoginWrapper.CreateWebView("https://arun-zone-dev-ed.my.salesforce.com/services/oauth2/authorize?response_type=code&client_id=3MVG9ZL0ppGP5UrDhS8a_1kOJZ5ihoBL70D8.rWXY2sIkEwjBOA8MDB10od0aOdu_jhzcLqw2F3t6nv0M2pWZ&redirect_uri=https://arun-zone-dev-ed.my.salesforce.com/auth/success");
           
            MainPage = new WebWrapper("https://test-mon.cs95.force.com/wheat/services/oauth2/authorize?response_type=code&client_id=3MVG9XmM8CUVepGaWq.XTuUtlm9_LWviPULVvlqxitqz5BBC7O9H7V2qxf5jmcNh7Y_QWWGi32jqkoPWfF2_u&redirect_uri=https://test.salesforce.com/services/oauth2/success");

            MainPage.Title = "Salesforce Login";

           // InitNavigation();
        }

        public static void BuildDependencies()
        {
            // Do you want to use fake services that DO NOT require real backend or internet connection?
            // Set to true the value to use fake services, false if you want to use Azure Services.
            AppSettings.UseFakes = true;

            Locator.Instance.Build();
        }

        private Task InitNavigation()
        {
            var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.NavigateToAsync<ExtendedSplashViewModel>();
        }

        protected override void OnStart()
        {
            MobileCenter.Start($"ios={AppSettings.MobileCenterAnalyticsIos};uwp={AppSettings.MobileCenterAnalyticsWindows};android={AppSettings.MobileCenterAnalyticsAndroid}", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
