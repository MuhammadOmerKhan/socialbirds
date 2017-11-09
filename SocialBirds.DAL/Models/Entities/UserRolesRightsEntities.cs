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
    public class User
    {
        public int UserID { get; set; }

        public string Email { get; set; }

        public string UserPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string FullName { get; set; }

        public int UserType { get; set; }

        public int? BaseApplicationID { get; set; }

        public int? PictureID { get; set; }

        public string PictureURL { get; set; }

        public bool IsCPUser { get; set; }

        public string MobileNo { get; set; }

        public string CountryCode { get; set; }

        public short RecordStatus { get; set; }

        public string VerificationCode { get; set; }

        public string ReasonForDeactivation { get; set; }

        public int? AssociatedCompanyID { get; set; }

        public string UniqueID { get; set; }

        public int TotalRecords { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string Occupation { get; set; }
    }
    public class UserRolesRight
    {
        public int RolesRightID { get; set; }

        public int RightID { get; set; }

        public int RoleID { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var pi in this.GetType().GetProperties())
            {
                if (!first)
                {
                    sb.Append("&");
                }
                first = false;
                sb.Append(pi.Name);
                sb.Append("=");

                sb.Append(pi.GetValue(this, null));
            }
            return sb.ToString();
        }
    }
}
