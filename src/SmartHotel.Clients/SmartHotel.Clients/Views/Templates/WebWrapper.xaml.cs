using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.Services.SalesforceWebservices;
using FFImageLoading.Args;

namespace SmartHotel.Clients.Core.Views.Templates
{

    public partial class WebWrapper : ContentPage
    {
        private string salesforceUrlBase;

        //private string testDisconnect = @"https://usqa-mon.cs3.force.com/wheat/services/revoke?token={0}&callback={1}";

        public WebView webView;
        private bool passOnce;
        private bool passOnceLogOff;
        private string urlSalesforceAuth;
        private bool passWait; private string navigatingURL;
        string currentNavigationURL;
        private static int logoutCount = 0;
        private static int AuthCount = 0;
        private static int passWordChangeCount = 0;
        public WebWrapper(string URL)
        {
            InitializeComponent();

            salesforceUrlBase = URL;

            CreateWebView(URL);
        }

        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            WebView theBrowser = (WebView)sender;
            var url = (((WebView)sender).Source as UrlWebViewSource).Url;
            System.Diagnostics.Debug.WriteLine("Navigated URL -- " + url);
             ValidateReturnLogin(theBrowser);
        }

        public void CreateWebView(string URL)
        {
            logoutCount = 0;
            salesforceUrlBase = URL;

            passOnce = false;
            passOnceLogOff = false;
            passWait = false;

            //webView = new WebView();
            webView = new NativeWebView();

            //urlSalesforceAuth = string.Format(salesforceUrlBase, ConnectionInfos.Instance.ConsumerKey, Data.UrlAuthSuccess);
            //if (AppConstants.SFPointing == "QA")
            //{
            //    urlSalesforceAuth = string.Format(salesforceUrlBase, ConnectionInfos.Instance.ConsumerKey, AppConstants.UrlAuthSuccessQA);
            //}
            //else if (AppConstants.SFPointing == "Prod")
            //{
            //    urlSalesforceAuth = string.Format(salesforceUrlBase, ConnectionInfos.Instance.ConsumerKey, AppConstants.UrlAuthSuccessProd);
            //}
            ////System.Diagnostics.Debug.WriteLine("Ravi - CreateWebView - " + urlSalesforceAuth);
            webView.Source = URL;

            webView.Navigated -= WebView_Navigated;
            webView.Navigated += WebView_Navigated;
            webView.Navigating += WebView_Navigating;
            webView.HorizontalOptions = LayoutOptions.FillAndExpand;
            webView.VerticalOptions = LayoutOptions.FillAndExpand;

            Content = webView;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            var url = (((WebView)sender).Source as UrlWebViewSource).Url;
            System.Diagnostics.Debug.WriteLine("WebView_Navigating - " + url);
            navigatingURL = url;

            // System.Diagnostics.Debug.WriteLine("Navigating sUrl - " + url);

            //if(url.Contains("frontdoor.jsp"))
            //{
            //    Device.StartTimer(TimeSpan.FromSeconds(60), () => {

            //        if(!url.Contains("success"))
            //        {
            //            Navigation.PopPopupAsync();
            //        }

            //        return false;
            //    });                                                         
            //}

            if (!passWait && (((WebView)sender).Source as UrlWebViewSource).Url.Contains("frontdoor.jsp"))
            {
                passWait = true;
                //if (Device.OS == TargetPlatform.iOS)
                //{
                PushPopUp("Please wait...");
                //}
            }

            if (navigatingURL.Contains("/identity/oauth/ui/AuthorizationPage"))
            {
                PushPopUp("Getting you Started...");
            }

            if (!(passWordChangeCount > 0) && navigatingURL.Contains("/system/security/ChangePassword?setupid=ChangePassword"))
            {
                passWordChangeCount++;
                PushPopUp("Changing Password...");
            }

            /* if (Device.OS == TargetPlatform.Android)
             {
                 //if (!passWait && (((WebView)sender).Source as UrlWebViewSource).Url.Contains("RemoteAccessAuthorizationPage.apexp"))
                 //{
                 //    passWait = true;
                 //    PushPopUp();
                 //}
                 if (AppConstants.SFPointing == "QA")
                 {
                     if (!passWait && (((WebView)sender).Source as UrlWebViewSource).Url.Contains("authorize?response_type=code"))
                     {
                         passWait = true;
                         PushPopUp("Please wait...");
                     }
                 }

                 //authorize?response_type=code
                 //show pop up
             }*/

        }

        private async void PushPopUp(string msg)
        {
           // await Navigation.PushPopupAsync(new WaitPopUpLogin(msg));
        }


        private async Task ValidateReturnLogin(WebView theBrowser) {
            System.Diagnostics.Debug.WriteLine("Ravi - ValidateReturnLogin - outside if - sUrl - " + (theBrowser.Source as UrlWebViewSource).Url);
            string sUrl = (theBrowser.Source as UrlWebViewSource).Url;
            if (sUrl.Contains("?code="))
            {
                int pFrom = sUrl.IndexOf("?code=") + "?code=".Length;

               
                string code = sUrl.Substring(pFrom);
                Debug.WriteLine("code is"+code);
                ConnectionInfos.Instance.code = code;
               bool Success =  await SalesforceWebService.Instance.ConnectQA(ConnectionInfos.Instance);
                if(Success) {
                    MessagingCenter.Send<WebWrapper>(this, "ShowMainPage");
                }

            }

                

            }

        //TO BE IMPLEMENTED
        //private async Task ValidateReturnLogin(WebView theBrowser)
        //{
        //    //System.Diagnostics.Debug.WriteLine("Ravi - ValidateReturnLogin - outside if - sUrl - " + (theBrowser.Source as UrlWebViewSource).Url);

        //    if (Device.OS == TargetPlatform.Android)
        //    {
        //        if (AppConstants.SFPointing == "QA")
        //        {
        //            if (passWait && (theBrowser.Source as UrlWebViewSource).Url.Contains("login?ec=302"))///_ui/identity/oauth/ui/AuthorizationPage
        //            {
        //                passWait = false;
        //                Navigation.PopPopupAsync();
        //            }
        //        }
        //        if ((theBrowser.Source as UrlWebViewSource).Url.Contains("/_ui/identity/oauth/ui/AuthorizationPage"))
        //        {
        //            PushPopUp("Getting you Started...");
        //        }
        //    }

        //    if (passOnce == false)
        //    {
        //        string sUrl = (theBrowser.Source as UrlWebViewSource).Url;
        //        //System.Diagnostics.Debug.WriteLine("Ravi - ValidateReturnLogin - inside if - sUrl - " + sUrl);

        //        if (sUrl.Contains("?code="))
        //        {
        //            passOnce = true;

        //            // Retreive code
        //            string code = StringExtensions.GetFromTo(sUrl, "?code=", "&");

        //            if (code != null || code != String.Empty)
        //            {
        //                currentNavigationURL = sUrl;
        //                MessagingCenter.Send<LocalService.SalesForceWebPage>(this, "SuccessLoginSF");
        //                //await Navigation.PopPopupAsync();
        //                // Replace %3D by =
        //                code = code.Replace("%3D", "=");

        //                // Succes login                         
        //                ConnectionInfos.Instance.code = code;

        //                await Data.Instance.ConnectQA(ConnectionInfos.Instance);

        //                passOnceLogOff = false;
        //                //if (Device.OS == TargetPlatform.iOS)
        //                //{
        //                //await Navigation.PopPopupAsync();
        //                //Navigation.PopPopupAsync();
        //                //}
        //                if (Data.Instance.IsConnected && !Data.Instance.IsLoggedOff)
        //                {
        //                    MessagingCenter.Send<LocalService.SalesForceWebPage>(this, "ShowMainPage");
        //                    MessagingCenter.Send<LocalService.SalesForceWebPage>(this, "Connected");
        //                    //MessagingCenter.Subscribe<UserMenuList>(this, "LogOffMenu", (sender) =>
        //                    //{
        //                    //    // do something whenever the message is sent
        //                    //    DoTheLogOff();
        //                    //});

        //                    MessagingCenter.Subscribe<MasterDetailNavigation>(this, "LogOffMenu", (sender) =>
        //                    {
        //                        //System.Diagnostics.Debug.WriteLine("Ravi - MC - inside LogOffMenu");
        //                        // do something whenever the message is sent
        //                        DoTheLogOff();
        //                        MessagingCenter.Unsubscribe<MasterDetailNavigation>(this, "LogOffMenu");
        //                    });

        //                }
        //                else
        //                {
        //                    // Disconnect
        //                    //DoTheLogOff();

        //                    //System.Diagnostics.Debug.WriteLine("Ravi - ValidateReturnLogin else part - " + sUrl);

        //                    //MessagingCenter.Send<LocalService.SalesForceWebPage>(this, "LogOff");
        //                    passOnce = false;
        //                    if (AppConstants.SFPointing == "QA")
        //                    {
        //                        this.webView.Source = AppConstants.URLLogOutQA;
        //                    }
        //                    else if (AppConstants.SFPointing == "Prod")
        //                    {
        //                        this.webView.Source = AppConstants.URLLogOutProd;
        //                    }



        //                }
        //            }
        //        }
        //        else if (sUrl.Contains("logout.jsp"))
        //        {
        //            if (Device.OS == TargetPlatform.iOS)
        //            {
        //                if (logoutCount == 0)
        //                {
        //                    passOnce = false;
        //                    if (AppConstants.SFPointing == "QA")
        //                    {
        //                        this.webView.Source = AppConstants.URLLogOutQA;
        //                    }
        //                    else if (AppConstants.SFPointing == "Prod")
        //                    {
        //                        this.webView.Source = AppConstants.URLLogOutProd;
        //                    }
        //                    logoutCount = logoutCount + 1;
        //                    return;
        //                }
        //            }

        //            if (logoutCount == 2)
        //            {
        //                //System.Diagnostics.Debug.WriteLine("Ravi - logoutCount - " + logoutCount.ToString());
        //                await Task.Run(async () => { await Task.Delay(250); });
        //            }
        //            //System.Diagnostics.Debug.WriteLine("Ravi - logout.jsp" );
        //            passOnce = true;
        //            MessagingCenter.Send<LocalService.SalesForceWebPage>(this, "LogOffComplete");
        //        }
        //    }

        //    if (navigatingURL.Contains("frontdoor.jsp") && (theBrowser.Source as UrlWebViewSource).Url.Contains("RemoteAccessAuthorizationPage.apexp?"))
        //    {
        //        //System.Diagnostics.Debug.WriteLine("It Gets Here... "+passOnce);
        //        currentNavigationURL = (theBrowser.Source as UrlWebViewSource).Url;
        //        //System.Diagnostics.Debug.WriteLine("Navigator Details " + Navigation.ToString());
        //        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
        //        {
        //            if (AuthCount < 2 && currentNavigationURL.Contains("RemoteAccessAuthorizationPage.apexp?"))
        //            {
        //                // returning true will fire task again in 2 minutes.
        //                //Set Count variable for the number of minutes you want to check
        //                AuthCount++;
        //                //System.Diagnostics.Debug.WriteLine("Timer Gonna Repeat ");
        //                return true;
        //            }

        //            if (AuthCount > 0)
        //            {
        //                //System.Diagnostics.Debug.WriteLine("Trying To Pop");
        //                Navigation.PopPopupAsync();
        //            }

        //            //System.Diagnostics.Debug.WriteLine(" Timer Stopped ");
        //            // No longer need to recur. Stops firing task
        //            return false;
        //        });

        //        //if it is the first timers login it will keep staying here for a long period of time,
        //        //So we wait for some time and check if the navigated url is Same. if so we will pop the please wait screen.

        //    }

        //    if ((theBrowser.Source as UrlWebViewSource).Url.Contains("/security/ChangePassword?"))
        //    {
        //        currentNavigationURL = (theBrowser.Source as UrlWebViewSource).Url;
        //        Navigation.PopPopupAsync();

        //    }
        //    if ((theBrowser.Source as UrlWebViewSource).Url.Contains("/services/oauth2/success"))
        //    {
        //        Navigation.PopPopupAsync();

        //    }

        //    if (navigatingURL.Contains("/ChangePassword?setupid=ChangePassword") && ((theBrowser.Source as UrlWebViewSource).Url.Contains("RemoteAccessAuthorizationPage.apexp?")))
        //    {
        //        Navigation.PopAsync();
        //    }
        //}

        //private void DoTheLogOff()
        //{
        //    //System.Diagnostics.Debug.WriteLine("Ravi - DoTheLogOff");

        //    if (passOnceLogOff == false)
        //    {
        //        passOnceLogOff = true;
        //        passOnce = false;
        //        MessagingCenter.Send<LocalService.SalesForceWebPage>(this, "LogOff");
        //    }

        //}
    }

    public class NativeWebView : WebView
    {
        public void ClearCache()
        {

        }
    }
}



