using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Views
{
    public partial class InitialPleaseWait : PopupPage
    {

        public InitialPleaseWait()
        {
           // System.Diagnostics.Debug.Print("The Log is Presented");
            InitializeComponent();

            //this.lblMsg.Text = "Getting you Started . . . ";
        }
        public InitialPleaseWait(string message)
        {
            //this.Label = message ;
            //lbl_msg.Text = message;
            InitializeComponent();
            lbl_msg.Text = message;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}





