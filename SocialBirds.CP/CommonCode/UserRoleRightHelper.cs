﻿using SocialBirds.DAL.DataServices;
using SocialBirds.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBirds.CommonCode
{
    public static class UserRoleRightHelper
    {

        public static CPRole ConvertUMRoleToCPRole(Role umRole)
        {
            CPRole cpRole = null;

            if (umRole != null)
            {
                cpRole = new CPRole();

                cpRole.CPRoleID = umRole.RoleID;
                cpRole.RoleName = umRole.RoleName;
                cpRole.SystemRole = umRole.IsSystemRole;
            }

            return cpRole;
        }

        public static List<CPRole> ConvertUMRolesToCPRoles(List<Role> lstUMRoles)
        {
            List<CPRole> lstCPRoles = null;

            if (lstUMRoles != null && lstUMRoles.Count > 0)
            {
                lstCPRoles = lstUMRoles.Where(umRole => umRole != null).Select(umRole => ConvertUMRoleToCPRole(umRole)).ToList();
            }

            return lstCPRoles;
        }
        public static CPRight ConvertUMRightToCPRight(Right umRight)
        {
            CPRight cpRight = null;

            if (umRight != null)
            {
                cpRight = new CPRight();

                cpRight.RightID = umRight.RightID;
                cpRight.RightCode = umRight.RightCode;
                cpRight.RightName = umRight.RightName;
                cpRight.RightType = umRight.RightType;
                cpRight.DescriptionAr = string.Empty;
                cpRight.DescriptionEn = string.Empty;

                int AppliesToMenuItemID = 0;

                int.TryParse(umRight.Tag, out AppliesToMenuItemID);

                cpRight.AppliesToMenuItemID = AppliesToMenuItemID;

                if (umRight.Status == 1)
                {
                    cpRight.Enabled = true;
                }
                else
                {
                    cpRight.Enabled = false;
                }
            }

            return cpRight;
        }

        public static List<CPRight> ConvertUMRightsToCPRights(List<Right> lstUMRights)
        {
            List<CPRight> lstCPRights = null;

            if (lstUMRights != null && lstUMRights.Count > 0)
            {
                lstCPRights = lstUMRights.Where(umRight => umRight != null).Select(umRight => ConvertUMRightToCPRight(umRight)).ToList();
            }

            return lstCPRights;
        }
        public static List<CPRole> GetAllRoles()
        {
            List<CPRole> lstCPRoles = null;

            RolesListResult rolesListResult = UserModuleHelper.GetAllRoles();

            if (rolesListResult.WasSuccessfull)
            {
                lstCPRoles = ConvertUMRolesToCPRoles(rolesListResult.lstRoles);
            }

            return lstCPRoles;
        }
        public static List<CPRight> GetAllRights()
        {
            List<CPRight> lstCPRights = null;

            RightsListResult rightsListResult = UserModuleHelper.GetAllRights();

            if (rightsListResult.WasSuccessfull)
            {
                lstCPRights = ConvertUMRightsToCPRights(rightsListResult.lstRights);
            }

            return lstCPRights;
        }
        public static List<CPRight> GetAllRightsByRoleID(int roleID)
        {
            List<CPRight> lstCPRights = null;

            RightsListResult rightsListResult = UserModuleHelper.GetAllRightsByRoleID(roleID);

            if (rightsListResult.WasSuccessfull)
            {
                lstCPRights = ConvertUMRightsToCPRights(rightsListResult.lstRights);
            }

            return lstCPRights;
        }
        public static void AddRightToRole(CPRoleRight cpRoleRight)
        {
            UserRolesRight rolesRight = ConvertCPRoleRightToUMRoleRight(cpRoleRight);

            if (rolesRight != null && rolesRight.RightID > 0 && rolesRight.RoleID > 0)
            {
                UserModuleHelper.GrantRightToRole(rolesRight);
            }
        }

        public static void RemoveRightFromRole(CPRoleRight cpRoleRight)
        {
            UserRolesRight rolesRight = ConvertCPRoleRightToUMRoleRight(cpRoleRight);

            if (rolesRight != null && rolesRight.RightID > 0 && rolesRight.RoleID > 0)
            {
                UserModuleHelper.DenyRightToRole(rolesRight);
            }
        }
        public static UserRolesRight ConvertCPRoleRightToUMRoleRight(CPRoleRight cpRoleRight)
        {
            UserRolesRight umRoleRight = null;

            if (cpRoleRight != null)
            {
                umRoleRight = new UserRolesRight();

                umRoleRight.RightID = cpRoleRight.RightID;
                umRoleRight.RoleID = cpRoleRight.CPRoleID;
            }

            return umRoleRight;
        }
    }
}