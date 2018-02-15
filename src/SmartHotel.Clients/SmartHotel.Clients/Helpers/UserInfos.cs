using System;
using System.Threading;

namespace SmartHotel.Clients.Core.Helpers
{
    public class UserInfos
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string sfdc_community_url { get; set; }
        public string sfdc_community_id { get; set; }
        public string signature { get; set; }
        public string scope { get; set; }
        public string id_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public bool IsRefreshing { get; set; }
        public bool IsRefreshingReg { get; set; }
        public bool ContinueTimer { get; set; }
        public bool IsOffline { get; set; }
        public bool IsFirstSynced { get; set; }
        public bool IsOfflineToOnline { get; set; }

        private bool isSyncing;
        public bool IsSyncing
        {
            get
            {
                return isSyncing;
            }
            set
            {
                if (value != isSyncing)
                {
                    isSyncing = value;
                    //MessagingCenter.Send(new ContentPage(), "IsSyncing", isSyncing);
                }
            }
        }
        public bool IsAlreadyLogin { get; set; }

        private CancellationTokenSource tsc = new CancellationTokenSource();
        private CancellationToken cancellationToken;
        public CancellationToken CancellationToken
        {
            get
            {
                return cancellationToken;
            }
        }

        //public string userId
        //{
        //    get
        //    {
        //        if (_userId == null)
        //        {
        //            _userId = string.Empty;
        //        }
        //        if (id != null && id != string.Empty)
        //        {
        //            string temp = id.TrimEnd().Substring(id.LastIndexOf("/") + 1, 18);
        //            _userId = temp;
        //        }

        //        if (AppConstants.SFPointing == "Dev")
        //        {
        //            // _userId = "005S0000004P2C6";
        //            //_userId = "005S0000004PDiS";
        //            _userId = "005S0000004PDiS";
        //        }

        //        return _userId;
        //    }
        //    set
        //    {
        //        _userId = value;
        //    }
        //}
        //private string _userId;

        #region " Single Instance "
        private static UserInfos instance;
        public static UserInfos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInfos();
                }
                return instance;
            }
        }

        private UserInfos()
        {
        }
        #endregion

        public void MakeUserNull()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        public override string ToString()
        {
            string returnValue;
            returnValue = "access_token: " + Instance.access_token + Environment.NewLine;
            returnValue += "refresh_token: " + Instance.refresh_token + Environment.NewLine;
            returnValue += "sfdc_community_url: " + Instance.sfdc_community_url + Environment.NewLine;
            returnValue += "sfdc_community_id: " + Instance.sfdc_community_id + Environment.NewLine;
            returnValue += "signature: " + Instance.signature + Environment.NewLine;
            returnValue += "scope: " + Instance.scope + Environment.NewLine;
            returnValue += "id_token: " + Instance.id_token + Environment.NewLine;
            returnValue += "instance_url: " + Instance.instance_url + Environment.NewLine;
            returnValue += "id: " + Instance.id + Environment.NewLine;
            returnValue += "token_type: " + Instance.token_type + Environment.NewLine;
            returnValue += "issued_at: " + Instance.issued_at;

            return returnValue;
        }

        public void CreateCancellationToken()
        {
            tsc = new CancellationTokenSource();
            cancellationToken = tsc.Token;
        }

        public void CancelTask()
        {
            if (cancellationToken != null && tsc != null)
            {
                tsc.Cancel();
            }
        }
    }

    public class UserInfosOffline
    {
        public UserInfosOffline()
        {

        }
        public UserInfosOffline(UserInfos objUserInfos)
        {
            //userId = objUserInfos.userId;
            access_token = objUserInfos.access_token;
            refresh_token = objUserInfos.refresh_token;
            sfdc_community_url = objUserInfos.sfdc_community_url;
            sfdc_community_id = objUserInfos.sfdc_community_id;
            signature = objUserInfos.signature;
            scope = objUserInfos.scope;
            id_token = objUserInfos.id_token;
            instance_url = objUserInfos.instance_url;
            id = objUserInfos.id;
            token_type = objUserInfos.token_type;
            issued_at = objUserInfos.issued_at;
            UserName = objUserInfos.UserName;
            UserRole = objUserInfos.UserRole;
            IsRefreshing = objUserInfos.IsRefreshing;
            IsRefreshingReg = objUserInfos.IsRefreshingReg;
            ContinueTimer = objUserInfos.ContinueTimer;
            IsFirstSynced = objUserInfos.IsFirstSynced;
            createdDate = DateTime.Now;
        }

        public DateTime createdDate { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string sfdc_community_url { get; set; }
        public string sfdc_community_id { get; set; }
        public string signature { get; set; }
        public string scope { get; set; }
        public string id_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public bool IsRefreshing { get; set; }
        public bool IsRefreshingReg { get; set; }
        public bool ContinueTimer { get; set; }
        public bool IsOffline { get; set; }
        public bool IsFirstSynced { get; set; }
        public bool IsAlreadyLogin { get; set; }

        //[PrimaryKey]
        //public string userId
        //{
        //    get
        //    {
        //        return _userId;
        //    }
        //    set
        //    {
        //        _userId = value;
        //    }
        //}
        //private string _userId;

        //#region " Single Instance "
        //private static UserInfos instance;
        //public static UserInfos Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new UserInfos();
        //        }
        //        return instance;
        //    }
        //}

        //public UserInfos()
        //{
        //}
        //#endregion

    }

}
