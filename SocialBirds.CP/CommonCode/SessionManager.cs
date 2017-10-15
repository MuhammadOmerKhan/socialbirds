using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialBirds.CP.CommonCode
{
    public class SessionManager
    {
        private static SessionStorageType m_SessionStorage = SessionStorageType.NotSpecified;

        public static SessionStorageType SessionStorage { get { return m_SessionStorage; } set { m_SessionStorage = value; } }

        private static void checkSessionStorage()
        {
            if (m_SessionStorage == SessionStorageType.NotSpecified)
            {
                string sessionStoreage = "httpsession";
                if (string.IsNullOrEmpty(sessionStoreage))
                {
                    m_SessionStorage = SessionStorageType.HTTPSession;
                }
                else
                {
                    sessionStoreage = sessionStoreage.ToLower();
                    switch (sessionStoreage)
                    {
                        case "httpsession":
                            m_SessionStorage = SessionStorageType.HTTPSession;
                            break;
                        case "cookie":
                            m_SessionStorage = SessionStorageType.Cookie;
                            break;
                        default:
                            m_SessionStorage = SessionStorageType.HTTPSession;
                            break;
                    }
                }
            }
        }

        public static T Get<T>(string aKey)
        {
            T retVal = default(T);
            try
            {
                checkSessionStorage();
                switch (m_SessionStorage)
                {
                    case SessionStorageType.HTTPSession:
                        retVal = (T)HttpContext.Current.Session[aKey];
                        break;
                    case SessionStorageType.Cookie:
                        retVal = CookieHelper.GetObjectFromCookie<T>(aKey);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return retVal;
        }

        public static void Set<T>(string aKey, T aValue)
        {
            checkSessionStorage();

            switch (m_SessionStorage)
            {
                case SessionStorageType.HTTPSession:
                    HttpContext.Current.Session[aKey] = aValue;
                    break;
                case SessionStorageType.Cookie:
                    //CookieHelper.SetObjectToCookie(aKey, aValue);
                    break;
            }
        }
        public static void ClearKey(string aKey)
        {
            checkSessionStorage();

            switch (m_SessionStorage)
            {
                case SessionStorageType.HTTPSession:
                    HttpContext.Current.Session[aKey] = null;
                    break;
                case SessionStorageType.Cookie:
                    //CookieHelper.SetObjectToCookie(aKey, "");
                    break;
            }
        }

    }


    public enum SessionStorageType : int
    {
        NotSpecified = 1,
        HTTPSession = 2,
        Cookie = 3
    }
}