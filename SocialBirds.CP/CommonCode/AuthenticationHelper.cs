using SocialBirds.DAL.DataServices;
using SocialBirds.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialBirds.CP.CommonCode
{
    public class AuthenticationHelper
    {
        public const string USER_COOKIE_NAME = "SMTCookie";
        public const string USER_COOKIE_EXPIRY_DATE_KEY = "expirydate";
        public const string USER_COOKIE_EMAIL_KEY = "emailaddress";
        public const string USER_COOKIE_USER_ID_KEY = "userid";
        public const string USER_COOKIE_HASH_KEY = "MD5Hash";

        public SessionUserEntity User
        {
            get
            {
                /* no need for this check as it will be too much to authenticateuserfromcookie every time 
                 * this property is called and this property is being called extensively at many places
                if (SessionHelper.SessionUserEntity == null)
                {
                    AuthenticateUserFromCookie();
                }
                 */
                return SessionHelper.SessionUserEntity;
            }
            set
            {
                SessionHelper.SessionUserEntity = value;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return (SessionHelper.SessionUserEntity != null);
            }
        }

        /// <summary>
        /// Validate PP user for subscription, if user is active and user's subscription exists and user's subscription is active as well then return empty string. 
        /// If user is active, user's subscription exists and user's subscription is not active then return "Subscription not active".
        /// If user is active and user's subscription does not exists then return "Treat user as a free user".
        /// Otherwise return "User is not active".
        /// </summary>
        public string ValidatePPUserSubscription(SessionUserEntity user)
        {
            string errorMsg = string.Empty;

            if (user == null || !user.IsActive)
            {
                errorMsg = "Error- Failed to login";
            }
            return errorMsg;
        }

        public string LoginPPUser(SessionUserEntity user, string rememberMe)
        {
            string loginData = string.Empty;
            string errorMsg = ValidatePPUserSubscription(user);

            if (string.IsNullOrEmpty(errorMsg))
            {
                user.SessionID = HttpContext.Current.Session.SessionID;
                SessionHelper.SessionUserEntity = SessionHelper.getSessionUserEntityFromUser(user);

            }
            return loginData;
        }

        public string LoginUser(SessionUserEntity user, string rememberMe)
        {
            UrlHelper Url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string loginData = string.Empty;
            if (user != null)
            {
                loginData = LoginPPUser(user, rememberMe);
            }
            return loginData;
        }

        public static DateTime ExpireCookieOn_CPUser
        {
            get
            {
                return DateTime.Now.AddDays(4);
            }
        }
        public void ResetSession()
        {
            SessionHelper.SessionUserEntity = null;
            SessionHelper.MessageForCurrentUser = null;
            SessionHelper.MessageForSubPkgExpFreeUser = null;
        }

        public void Logout(bool removeCookie = true)
        {
            if (HttpContext.Current.Session.Keys.Count > 0)
            {
                ResetSession();
            }
        }

        public void ForceLogout(string forceLogoutReason, bool removeCookie = false)
        {
            Logout(removeCookie);
            SessionHelper.ForceLogOut = forceLogoutReason;
        }

        public SessionUserEntity ConvertFMUserToPPUserEntity(User authenticatedUser)
        {
            SessionUserEntity user = new SessionUserEntity();

            user.UserID = authenticatedUser.UserID;
            user.Email = authenticatedUser.Email;
            user.FirstName = authenticatedUser.FirstName;
            user.MiddleName = authenticatedUser.MiddleName;
            user.LastName = authenticatedUser.LastName;
            user.IsActive = authenticatedUser.IsActive;
            user.DateOfBirth = authenticatedUser.DateOfBirth;
            user.Gender = authenticatedUser.Gender;
            user.DisplayName = authenticatedUser.DisplayName;
            user.DisplayPictureURL = authenticatedUser.DisplayPictureURL;
            return user;
        }

        #region Define as Singleton

        public static AuthenticationHelper Instance
        {
            get
            {
                return new AuthenticationHelper();
            }
        }

        private AuthenticationHelper()
        {
        }

        #endregion

    }
}