using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialBirds.CP.CommonCode;
using SocialBirds.Models;
using SocialBirds.DAL.DataServices;
using SocialBirds.CommonCode;
using SocialBirds.DAL.Services;
using SocialBirds.DAL.Models.Entities;

namespace SocialBirds.CP.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Roles(int? roleID)
        {
            RolesAndRightsModel model = new RolesAndRightsModel();
            //int baseAppID = GlobalAppConfigs.ArgaamPlusAppID;
            model.Roles = UserRoleRightHelper.GetAllRoles();
            roleID = roleID == null ? ((model.Roles != null) ? model.Roles[0].CPRoleID : 0) : roleID;
            model.SelectedRoleID = roleID.Value;
            model.AllRights = UserRoleRightHelper.GetAllRights();
            model.AllMenuItems = UserServices.Instance.GetAllMenutItems();
            model.SelectedRights = UserRoleRightHelper.GetAllRightsByRoleID(model.SelectedRoleID);
            return View(model);
        }
        public JsonResult ProcessRight(FormCollection option)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            CPRoleRight entity = new CPRoleRight();
            entity.RightID = int.Parse(option["RightID"]);
            entity.CPRoleID = short.Parse(option["RoleID"]);
            if (bool.Parse(option["Option"]))
            {
                UserRoleRightHelper.AddRightToRole(entity);
                result.Data = "The Right has been granted.";
            }
            else
            {
                UserRoleRightHelper.RemoveRightFromRole(entity);
                result.Data = "The Right has been Revoked.";

            }
            return result;
        }

    }
}
