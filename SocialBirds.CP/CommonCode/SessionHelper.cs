using SocialBirds.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SocialBirds.CP.CommonCode
{
    public static class SessionHelper
    {
        private const string USER_SESSION_KEY = "SESSION_USER_ENTITY";
        private const string SUBSCRIPTION_PACKAGE_PAGES = "SubscriptionPackagePages";
        private const string SUBSCRIPTION_PACKAGE_PAGES_IDs = "SubscriptionPackagePageIDs";
        private const string ACTIVE_MENU = "ACTIVE_MENU";
        private const string CURRENT_ENTITYID = "CURRENT_ENTITYID";
        private const string CONTROLLER = "CONTROLLER";
        private const string TOP_MENU_NAVIGATION = "TOP_MENU_NAVIGATION";
        private const string POPULAR_MENU_NAVIGATION = "POPULAR_MENU_NAVIGATION";
        private const string BUSINESS_FRAMES = "BUSINESS_FRAMES";
        private const string ENTITIES_DETAIL = "ENTITIES_DETAIL";
        private const string SEARCH_ENGINE_OPTIMIZATION = "SEARCH_ENGINE_OPTIMIZATION";
        private const string FORCE_LOG_OUT = "ForceLogOut";
        private const string COOKIE_FORCE_LOG_OUT = "COOKIE_FORCE_LOG_OUT";
        private const string IS_ARGAAM_LOGO = "IS_ARGAAM_LOGO";
        //private const string DATETIME_CHECKER = "DatetimeChecker";
        public const string FORCE_LOG_OUT_LOGGED_IN_ANOTHER_MACHINE = "LOGGED_IN_ANOTHER_MACHINE";
        public const string FORCE_LOG_OUT_SUBSCRIPTION_EXPIRED = "SUBSCRIPTION_EXPIRED";
        public const string FORCE_LOG_OUT_ACCOUNT_SUSPENDED = "ACCOUNT_SUSPENDED";
        public const string FORCE_LOG_OUT_LOGGED_OUT_FROM_CP = "LOGGED_OUT_FROM_CP";
        public const string FORCE_LOG_OUT_IRAPP_USER = "IRAPP_USER";
        public const string USER_SPECIFIC_MESSAGE = "USER_SPECIFIC_MESSAGE";
        public const string USER_SPECIFIC_MESSAGE_SUB_PKG_EXP_FREEUSER = "USER_SPECIFIC_MESSAGE_SUB_PKG_EXP_FREEUSER";
        public const string USER_EMAILUPDATE_MESSAGE = "USER_EMAILUPDATE_MESSAGE";
        public const string IS_USER_NOTIFIED_ON_RANK_UPDATE = "IS_USER_NOTIFIED_ON_RANK_UPDATE_RANK_{0}_USER_{1}";

        public static SessionUserEntity SessionUserEntity
        {
            get
            {
                return SessionManager.Get<SessionUserEntity>(USER_SESSION_KEY);
            }
            set
            {
                SessionManager.Set(USER_SESSION_KEY, value);
            }
        }

        public static SessionUserEntity getSessionUserEntityFromUser(SessionUserEntity user)
        {
            SessionUserEntity sessionUser = new SessionUserEntity();
            sessionUser.UserID = user.UserID;
            sessionUser.FirstName = user.FirstName;
            sessionUser.LastName = user.LastName;
            sessionUser.MiddleName = user.MiddleName;
            sessionUser.IsActive = user.IsActive;
            sessionUser.Email = user.Email;
            sessionUser.DateOfBirth = user.DateOfBirth;
            sessionUser.SessionID = user.SessionID;
            sessionUser.DisplayName = user.DisplayName;
            sessionUser.DisplayPictureURL = user.DisplayPictureURL;
            return sessionUser;
        }

        public static string ActiveMenu
        {
            get { return SessionManager.Get<string>(ACTIVE_MENU); }
            set { SessionManager.Set<string>(ACTIVE_MENU, value); }
        }

        public static short? EntityID
        {
            get { return SessionManager.Get<short?>(CURRENT_ENTITYID); }
            set { SessionManager.Set<short?>(CURRENT_ENTITYID, value); }
        }

        public static string Controller
        {
            get { return SessionManager.Get<string>(CONTROLLER); }
            set { SessionManager.Set<string>(CONTROLLER, value); }
        }

        public static List<EntitiesDetail> EntitiesDetail
        {
            get { return SessionManager.Get<List<EntitiesDetail>>(ENTITIES_DETAIL); }
            set { SessionManager.Set<List<EntitiesDetail>>(ENTITIES_DETAIL, value); }
        }
        public static string ForceLogOut
        {
            get
            {
                return SessionManager.Get<string>(FORCE_LOG_OUT);
            }
            set
            {
                SessionManager.Set<string>(FORCE_LOG_OUT, value);
            }
        }

        public static string MessageForCurrentUser
        {
            get
            {
                return SessionManager.Get<string>(USER_SPECIFIC_MESSAGE);
            }
            set
            {
                SessionManager.Set<string>(USER_SPECIFIC_MESSAGE, value);
            }
        }
        public static string MessageForSubPkgExpFreeUser
        {
            get
            {
                return SessionManager.Get<string>(USER_SPECIFIC_MESSAGE_SUB_PKG_EXP_FREEUSER);
            }
            set
            {
                SessionManager.Set<string>(USER_SPECIFIC_MESSAGE_SUB_PKG_EXP_FREEUSER, value);
            }
        }

        public static string CookieForceLogOut
        {
            get
            {
                return SessionManager.Get<string>(COOKIE_FORCE_LOG_OUT);
            }
            set
            {
                SessionManager.Set<string>(COOKIE_FORCE_LOG_OUT, value);
            }
        }
    }
}