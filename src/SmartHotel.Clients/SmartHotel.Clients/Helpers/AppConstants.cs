using System;
namespace SmartHotel.Clients.Core.Helpers
{
    public static class AppConstants
    {
        //public const string SFPointing = "Dev";
        /*pathto QA */
        public const string SFPointing = "QA";
        /*Path to prod*/
        //public const string SFPointing = "Prod";


        public const string ROLE_DEALER = "Dealer";
        public const string ROLE_ASSOCIATE = "Assoc";
        public const string ROLE_PROCO = "Proco";
        public const string ROLE_PROCO_ASSOCIATE = "Proco/Assoc";
        public const string SHOW_PENDING = "In Progress";
        public const string SHOW_COMPLETED = "Completed";
        public const string SHOW_PENDINGSYNC = "Pending Sync";
        public const bool ENABLE_LOGGING = false;

        //public const string UrlAuthClientQA = @"https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/authorize?response_type=code&client_id=3MVG98dostKihXN5k6aV.ZUmKpFM8AJ1h5PcOQgS_P4B5Ko75j3uxF1FilYs8SqMrv_Z3n4l24IpevjKB3ssN&redirect_uri={1}";
        //public const string UrlAuthSuccessQA = "https://test.salesforce.com/services/oauth2/success";
        //public const string UrlAuthTokenQA = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/token";
        //public const string URLLogOutQA = "https://usliondev-mon.cs1.force.com/wheatComm/secur/logout.jsp";
        //public const string URLRevokeTokenQA = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/revoke?token=";

        //public const string UrlAuthClientQA = @"https://usqa-mon.cs3.force.com/wheat/services/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}";
        //public const string UrlAuthSuccessQA = "https://test.salesforce.com/services/oauth2/success";
        //public const string UrlAuthTokenQA = "https://usqa-mon.cs3.force.com/wheat/services/oauth2/token";
        //public const string URLLogOutQA = "https://usqa-mon.cs3.force.com/wheat/secur/logout.jsp";
        //public const string URLRevokeTokenQA = "https://usqa-mon.cs3.force.com/wheat/services/oauth2/revoke?token=";

        //QA SF Pointing URLs
        public const string UrlAuthClientQA = @"https://arun-zone-dev-ed.my.salesforce.com/services/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}";
        public const string UrlAuthSuccessQA = "https://arun-zone-dev-ed.my.salesforce.com/auth/success";
        public const string UrlAuthTokenQA = "https://arun-zone-dev-ed.my.salesforce.com/services/oauth2/token";
        public const string URLLogOutQA = "https://arun-zone-dev-ed.my.salesforce.com/secur/logout.jsp";
        public const string URLRevokeTokenQA = "https://arun-zone-dev-ed.my.salesforce.com/services/oauth2/revoke?token=";
        public const String URL_QA_HOME = "https://arun-zone-dev-ed.my.salesforce.com";
        //public const String URL_QA_CUSTOMER_QUOTES = "https://test-mon.cs95.force.com/wheat/s/?redirect=cq";
        //public const String URL_QA_MY_INVENTORY = "https://test-mon.cs95.force.com/wheat/s/?redirect=inv";


        //PROD SF Pointing URLs
        public const string UrlAuthClientProd = @"https://mon.force.com/wheat/services/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}";
        public const string UrlAuthSuccessProd = "https://login.salesforce.com/services/oauth2/success";
        public const string UrlAuthTokenProd = "https://mon.force.com/wheat/services/oauth2/token";
        public const string URLLogOutProd = "https://mon.force.com/wheat/secur/logout.jsp";
        public const string URLRevokeTokenProd = "https://mon.force.com/wheat/services/oauth2/revoke?token=";
        public const String URL_PROD_HOME = "https://mon.force.com/wheat";
        public const String URL_PROD_CUSTOMER_QUOTES = "https://mon.force.com/wheat/s/?redirect=cq";
        public const String URL_PROD_MY_INVENTORY = "https://mon.force.com/wheat/s/?redirect=inv";

        //Attachment related constants
        public const double TOTALSIZE_LIMIT = 15;//use this in the screen logic.
        public const double SINGLE_LIMIT = 2.5;//use this in dependency classes

        //Offline functionality constants
        public const bool OfflineEnabled = true;
        public const double SYNC_TIME_IN_HOURS = 8;
        public const int OFFLINE_TIME_IN_DAYS = 1;
        public const int FOUR_OFFLINE_TIME_IN_DAYS = 4;
        public const string FORCE_SYNC_MESSAGE = "You have been offline for more than 7 days, please switch to online mode and sync your offline transactions";
        public const string FOUR_FORCE_SYNC_MESSAGE = "Warning, You have been offline for more than 4 days, Please go online soon to sync your offline transactions.";
        public const string CONNCTIVITY_MESSAGE = "This functionality is not available in offline.";
        public const string SYNCING_MESSAGE = "Your offline data is being set up. This may take several minutes, please wait.";
        public const string SYNCING_MESSAGE_TIMER = "Your offline data is being refresh, please wait.";

    }
}
