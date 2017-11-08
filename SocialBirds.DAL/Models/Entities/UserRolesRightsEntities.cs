using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBirds.DAL.Models.Entities
{
    class UserRolesRightsEntities
    {

    }
    public class CPRole
    {
        public int CPRoleID { get; set; }

        public string RoleName { get; set; }

        public bool SystemRole { get; set; }
    }

    public class CPRight
    {
        public int RightID { get; set; }

        public string RightCode { get; set; }

        public string RightName { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public int? AppliesToMenuItemID { get; set; }

        public bool Enabled { get; set; }

        public string RightType { get; set; }
    }

    public class CPRoleRight
    {
        public int CPRoleRightID { get; set; }

        public int CPRoleID { get; set; }

        public int RightID { get; set; }
    }
}
