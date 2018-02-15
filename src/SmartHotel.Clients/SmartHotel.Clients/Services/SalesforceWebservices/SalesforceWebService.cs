using System;
using System.Threading.Tasks;
using SmartHotel.Clients.Core.Helpers;
using ModernHttpClient;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

using System.Net;
//using InventoryManager.Entity.Params;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Threading;
using System.Diagnostics;

namespace SmartHotel.Clients.Core.Services.SalesforceWebservices
{
    public class SalesforceWebService
    {

        #region " Private Variables and Const "

        private bool isConnected;

        // For USLIONDEV use
        // private const string UrlAuthClient = "https://usliondev-mon.cs1.force.com/wheatComm"
        // For USQA use
        // private const string UrlAuthClient = "https://usqa-mon.cs30.force.com/wheatCommunity"
        // For Test connection use
        // private const string UrlAuthClient = "https://test.salesforce.com/services/oauth2/token";
        //"https://monsanto-us--usliondev.cs1.my.salesforce.com/app/mgmt/forceconnectedapps/forceAppDetail.apexp?applicationId=06PS00000004CLi&id=0CiS00000008WDX"
        private const string UrlAuthClient = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/token";
        //private const string UrlAuthClient = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/authorize";
        //private const string UrlAuthClient = "https://usqa-mon.cs3.force.com/wheat/services/oauth2/authorize";
        //private const string UrlAuthSuccess = "https://usliondev-mon.cs1.force.com/services/oauth2/success";
        //private const string UrlAuthToken = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/token";

        private const string UrlAuthClientOld = "https://monsfest-dev-ed.my.salesforce.com/services/oauth2/token";

        //private const string UrlAuthClient = @"https://usqa-mon.cs3.force.com/wheat/services/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}";
        //public const string UrlAuthSuccess = "https://test.salesforce.com/services/oauth2/success";
        //private const string UrlAuthRevoke = "https://usqa-mon.cs3.force.com/wheat/services/revoke?";
        //private const string UrlAuthToken = "https://usqa-mon.cs3.force.com/wheat/services/oauth2/token";
        //public const string URLLogOut = "https://usqa-mon.cs3.force.com/wheat/secur/logout.jsp";

        private const string UrlBase = "/services/apexrest/Monsfest/";
        private const string DataServices = "/services/data/v41.0/";

        private const string AutorizationWord = "Authorization";
        private const string BearerWord = "Bearer ";
        private const string AppJSonWord = "application/json";
        private const string AppUrlencoded = "urlencoded";
        #endregion

        #region " Public Variables and Properties "
        public string serviceUrl;

        public bool IsConnected
        {
            get
            {
                //Do After Doing App constants
                // if (AppConstants.OfflineEnabled == true)
                //{
                //   return true;
                //}

                return isConnected;
            }
        }

        private bool isLoggedOff;
        public bool IsLoggedOff
        {
            get
            {
                return isLoggedOff;
            }
        }

        public string LastQueryURL { get; set; }
        public string LastResultString { get; set; }
        #endregion

        #region " Single Instance "
        private static SalesforceWebService instance;
        public static SalesforceWebService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SalesforceWebService();
                }
                return instance;
            }
        }

        private SalesforceWebService()
        {
        }
        #endregion


        public async Task<bool> ConnectQA(ConnectionInfos connectInfos)
        {

            //       if (AppConstants.OfflineEnabled)
            //       {
            //           //lstType.Add(typeof(ListHeaderWO));
            //           //lstType.Add(typeof(UserInfosOffline));
            //           //lstType.Add(typeof(CustomerOrderDB));

            //           try
            //           {
            //               Repository<ListHeaderWO> repoListHeaderWO = new Repository<ListHeaderWO>();
            //await repoListHeaderWO.DeleteAllAsync();

            //               Repository<UserInfosOffline> repoUserInfosOffline = new Repository<UserInfosOffline>();
            //await repoUserInfosOffline.DeleteAllAsync();

            //Repository<ObjectFieldMap> repoCustomerOrderDB = new Repository<ObjectFieldMap>();
            //await repoCustomerOrderDB.DeleteAllAsync();

            //               //Task.WaitAll(t1, t2, t3);
            //           }
            //           catch(Exception ex)
            //           {
            //               var msg = ex.Message;
            //           }
            //       }

            isConnected = false;
            isLoggedOff = true;

            LastQueryURL = string.Empty;
            LastResultString = string.Empty;

            HttpClient authClient = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                authClient = new HttpClient();
            }
            else
            {
                authClient = new HttpClient(new NativeMessageHandler());
            }

            //set OAuth key and secret variables
            string sfdcConsumerKey = connectInfos.ConsumerKey;
            string sfdcConsumerSecret = connectInfos.ConsumerSecret;

            HttpContent content = null;
            string codenew = ConnectionInfos.Instance.code.Replace("%3D", "=");
            Debug.WriteLine("Code"+codenew);

            if (AppConstants.SFPointing == "QA")
            {
                
                content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "authorization_code"},
                    {"code", codenew},
                    {"client_id", "3MVG9ZL0ppGP5UrDhS8a_1kOJZ5ihoBL70D8.rWXY2sIkEwjBOA8MDB10od0aOdu_jhzcLqw2F3t6nv0M2pWZ"},
                    {"client_secret", "1254695708531707837"},

                    {"redirect_uri", "https://arun-zone-dev-ed.my.salesforce.com/auth/success"}
                }
                );
            }

            LastQueryURL = content.ToString();

            HttpResponseMessage message = null;

            if (AppConstants.SFPointing == "QA")
            {
                //message = await authClient.PostAsync(UrlAuthToken, content);
                message = await authClient.PostAsync(AppConstants.UrlAuthTokenQA, content);
            }
            else if (AppConstants.SFPointing == "Prod")
            {
                message = await authClient.PostAsync(AppConstants.UrlAuthTokenProd, content);
            }

            string responseString = await message.Content.ReadAsStringAsync();
            Debug.WriteLine(responseString);
            if (responseString.Length != 0)
            {
                if (!responseString.Contains("error_description"))
                {
                    JObject obj = JObject.Parse(responseString);

                    UserInfos.Instance.access_token = (string)obj["access_token"];
                    UserInfos.Instance.refresh_token = (string)obj["refresh_token"];
                    UserInfos.Instance.sfdc_community_url = (string)obj["sfdc_community_url"];
                    UserInfos.Instance.sfdc_community_id = (string)obj["sfdc_community_id"];
                    UserInfos.Instance.signature = (string)obj["signature"];
                    UserInfos.Instance.scope = (string)obj["scope"];
                    UserInfos.Instance.id_token = (string)obj["id_token"];
                    UserInfos.Instance.instance_url = (string)obj["instance_url"];
                    UserInfos.Instance.id = (string)obj["id"];
                    UserInfos.Instance.token_type = (string)obj["token_type"];
                    UserInfos.Instance.issued_at = (string)obj["issued_at"];

                    // Constante de l'URL
                    serviceUrl = UserInfos.Instance.instance_url;

                    isConnected = true;
                    isLoggedOff = false;



                }


            }
            return isConnected;
        }
    }
}