using System;
namespace SmartHotel.Clients.Core.Helpers
{
    public class ConnectionInfos
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string authURL { get; set; }

        public string code { get; set; }
        public string sfdc_community_url { get; set; }
        public string sfdc_community_id { get; set; }

        public string LoginPassword { get { return Password + Token; } }

        #region " Single Instance "
        private static ConnectionInfos instance;
        public static ConnectionInfos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionInfos();
                }
                return instance;
            }
        }

        //private ConnectionInfos()
        //{
        //    //set OAuth key and secret variables
        //    const string sfdcConsumerKey = "3MVG98dostKihXN5k6aV.ZUmKpFM8AJ1h5PcOQgS_P4B5Ko75j3uxF1FilYs8SqMrv_Z3n4l24IpevjKB3ssN";
        //    const string sfdcConsumerSecret = "2690845714756692471";
        //    //set to Force.com user account that has API access enabled
        //    //const string sfdcUserName = "ravikumar.kanasagra@in.fujitsu.com.liondev";
        //    //const string sfdcPassword = "Xamarin@1234";
        //    //const string sfdcToken = "YuLF7KnQFuzE3zKvQE3vQIMG";

        //    const string sfdcUserName = "testxamarin@usliondev.com";
        //    const string sfdcPassword = "Sfdc12345";
        //    const string sfdcToken = "";

        //    init(sfdcConsumerKey, sfdcConsumerSecret, sfdcUserName, sfdcPassword, sfdcToken);
        //}
        #endregion

        public ConnectionInfos()
        {
            //set OAuth key and secret variables
            //const string sfdcConsumerKeyDev = "3MVG9d8..z.hDcPLjjwItMD.QX0DI9eD.JHDvPna91GydFUThUKlqr.hPoEqF8nUHYukb.bJ9l3jxLRLVly53";
            //const string sfdcConsumerSecretDev = "3100585937607471396";
            const string authUrl = "https://monsfest-dev-ed.my.salesforce.com/secur/frontdoor.jsp?sid=";
            ////set to Force.com user account that has API access enabled
            //const string sfdcUserName = "mobile-users@monsfest.com";
            //const string sfdcPassword = "monSFest#2018";
            //const string sfdcToken = "9DuZ2Dy72BONlEF5QcoeEouX";

            const string sfdcConsumerKeyQA = "3MVG9pHRjzOBdkd8xU6Dxo9qLhrz78ob_A99x3EmZdw8fYzb83baLYTPLnaBFpy492pWJTpX9zdH9ftlBqjlI";
            const string sfdcConsumerSecretQA = "592126881025288666";
            //const string sfdcConsumerKeyQA = "3MVG9XmM8CUVepGaWq.XTuUtlm9_LWviPULVvlqxitqz5BBC7O9H7V2qxf5jmcNh7Y_QWWGi32jqkoPWfF2_u";
            //const string sfdcConsumerSecretQA = "1903837345587336976";

            //const string sfdcConsumerKeyProd = "3MVG99OxTyEMCQ3gN3Y4bUde_13_6ngVfkgdAuOC2MwupJB0ignBR982zZl3NcyI_cfbJoWWRRl4.q8SuGSCq";
            //const string sfdcConsumerSecretProd = "6055033674792995211";

            /*if (AppConstants.SFPointing == "QA")
            {
                init(sfdcConsumerKeyQA, sfdcConsumerSecretQA, "", "", "");
            }
            else if (AppConstants.SFPointing == "Prod")
            {
                init(sfdcConsumerKeyProd, sfdcConsumerSecretProd, "", "", "");
            }
            else
            {*/
            //By Defauld point to Development
            init(sfdcConsumerKeyQA, sfdcConsumerSecretQA, authUrl);
            //}
        }

        /*public ConnectionInfos(string consumerKey, string ConsumerSecret, string userName, string password, string token)
        {
            init(consumerKey, ConsumerSecret, userName, password, token);
        }
    */
        private void init(string consumerKey, string consumerSecret, string auth)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
           // UserName = userName;
            //Password = password;
            //Token = token;
            authURL = auth;

        }

    }


}
