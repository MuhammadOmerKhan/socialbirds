using SocialBirds.DAL.DataServices;
using SocialBirds.DAL.Models.Entities;
using SocialBirds.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using User = SocialBirds.DAL.Models.Entities.User;
namespace SocialBirds.CommonCode
{
    public class RolesListResult
    {
        public List<Role> lstRoles;
        public bool WasSuccessfull;
        public string ErrorMsg;
    }
    public class RightsListResult
    {
        public List<Right> lstRights;
        public bool WasSuccessfull;
        public string ErrorMsg;
    }
    public class OperationResult
    {
        public bool WasSuccessfull;
        public string ErrorMsg;
    }
    public static class UserModuleHelper
    {
        public static RolesListResult GetAllRoles()
        {
            RolesListResult rolesListResult = new RolesListResult();

            try
            {
                rolesListResult.lstRoles = UserServices.Instance.GetAllRoles();

                rolesListResult.WasSuccessfull = true;
            }
            catch (Exception exception)
            {
                rolesListResult.ErrorMsg = exception.Message;
            }

            return rolesListResult;
        }
        public static RightsListResult GetAllRights()
        {
            RightsListResult rightsListResult = new RightsListResult();

            try
            {
                rightsListResult.lstRights = UserServices.Instance.GetAllRights();
                rightsListResult.WasSuccessfull = true;
            }
            catch (Exception exception)
            {
                rightsListResult.ErrorMsg = exception.Message;
            }

            return rightsListResult;
        }
        public static RightsListResult GetAllRightsByRoleID(int roleID)
        {
            RightsListResult rightsListResult = new RightsListResult();

            try
            {
                rightsListResult.lstRights = UserServices.Instance.GetAllRightsByRole(roleID);
                rightsListResult.WasSuccessfull = true;
            }
            catch (Exception exception)
            {
                rightsListResult.ErrorMsg = exception.Message;
            }

            return rightsListResult;
        }
        public static OperationResult GrantRightToRole(UserRolesRight rolesRight)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                UserServices.Instance.GrantRightToRole(rolesRight.RightID, rolesRight.RoleID);
                operationResult.WasSuccessfull = true;
            }
            catch (Exception exception)
            {
                operationResult.ErrorMsg = exception.Message;
            }

            return operationResult;
        }
        public static OperationResult DenyRightToRole(UserRolesRight rolesRight)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                UserServices.Instance.DenyRightToRole(rolesRight.RightID, rolesRight.RoleID);
                operationResult.WasSuccessfull = true;
            }
            catch (Exception exception)
            {
                operationResult.ErrorMsg = exception.Message;
            }

            return operationResult;
        }
    }
    
}