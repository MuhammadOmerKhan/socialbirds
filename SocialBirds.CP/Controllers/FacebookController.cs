using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialBirds.CP.Controllers
{
    public class FacebookController : BaseController
    {
        public ActionResult Groups()
        {
            return View();
        }
    }
}