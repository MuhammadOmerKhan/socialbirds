using SocialBirds.CP.CommonCode;
using SocialBirds.DAL.DataServices;
using SocialBirds.DAL.Entities;
using SocialBirds.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialBirds.CP.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //public JsonResult Login(FormCollection form)
        //{
        //    JsonResult result = new JsonResult();
        //    try
        //    {
        //        string email = form["email"];
        //        string password = form["password"];
        //        var user = UserServices.Instance.Login(email, password.Encrypt());
        //        if (user != null)
        //        {
        //            result.Data = "success";
        //        }
        //        else
        //        {
        //            result.Data = "Failed to Login, try again!";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        result.Data = ex.Message;
        //    }
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;
        //}
        public JsonResult Login(FormCollection form)
        {
            AuthenticationHelper.Instance.ResetSession();

            JsonResult result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            string email = form["email"];
            string password = form["password"];
            string rememberMe = form["RememberMe"];

            SessionUserEntity user = null;
            try
            {
                var authenticatedUser = UserServices.Instance.Login(email, password.Encrypt());
                if (authenticatedUser != null)
                {
                    user = AuthenticationHelper.Instance.ConvertFMUserToPPUserEntity(authenticatedUser);
                    var message = AuthenticationHelper.Instance.LoginUser(user, rememberMe);
                    if (string.IsNullOrEmpty(message))
                    {
                        result.Data = "success";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Data = "failed";
            }
            if (SessionHelper.CookieForceLogOut == SessionHelper.FORCE_LOG_OUT_SUBSCRIPTION_EXPIRED)
            {
                result.Data = string.Format("Error- ForceLoggedOut");
                SessionHelper.CookieForceLogOut = string.Empty;
            }
            return result;
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(FormCollection form)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                User register = new User();
                register.Email = form["email"];
                register.Password = form["password"].Encrypt();
                register.FirstName = form["firstname"];
                register.MiddleName = form["middlename"];
                register.LastName = form["lastname"];
                register.IsActive = true;
                register.Gender = form["gender"];
                register.DateOfBirth = Convert.ToDateTime(form["dateofbirth"]);
                register.CreatedOn = DateTime.Now;
                var user = UserServices.Instance.Register(register);
                if (user != null)
                {
                    result.Data = "success";
                }
                else
                {
                    result.Data = "Failed to register, please try again!";
                }

            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
            }
            return result;
        }
    }
}