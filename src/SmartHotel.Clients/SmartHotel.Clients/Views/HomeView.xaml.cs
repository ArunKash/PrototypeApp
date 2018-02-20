using System.Threading.Tasks;
using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.ViewModels.Base;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
               base.OnAppearing();

            await Task.WhenAny<bool>(
                MonLogo.FadeTo(1,400)
            );

            await Task.WhenAny<bool>
                      (
                          WelcomeMsg.FadeTo(1,400)
                          
                         );

            await Task.WhenAny<bool>
                (
                          TouchpointFrame.RotateXTo(360, 500),
                          TouchpointFrame.FadeTo(1, 500),
                          TouchpointFrame.ScaleTo(1, 500),
                          ordersFrame.RotateXTo(360, 500),
                          ordersFrame.FadeTo(1, 500),
                          ordersFrame.ScaleTo(1, 500),

                          ForecastFrame.RotateXTo(360, 500),
                          ForecastFrame.FadeTo(1, 500),
                          ForecastFrame.ScaleTo(1, 500),

                          NearmeFrame.RotateXTo(360, 500),
                          NearmeFrame.FadeTo(1, 500),
                          NearmeFrame.ScaleTo(1, 500)
                     );
            

            //await Task.WhenAny<bool>
            //    (
            //             // NearmeFrame.RotateXTo(180, 400),
            //              NearmeFrame.FadeTo(1, 400),
            //              NearmeFrame.ScaleTo(1, 400)
            //         );
            



            //await Task.WhenAny<bool>
                //(
                          
                     //);
           

          



            StatusBarHelper.Instance.MakeTranslucentStatusBar(true);

            if (BindingContext is IHandleViewAppearing viewAware)
            {
                await viewAware.OnViewAppearingAsync(this);
            }

           
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is IHandleViewDisappearing viewAware)
            {
                await viewAware.OnViewDisappearingAsync(this);
            }
        }
    }
}