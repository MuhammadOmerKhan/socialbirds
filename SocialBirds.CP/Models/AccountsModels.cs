using SocialBirds.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialBirds.DAL.DataServices;
using SocialBirds.DAL.Models.Entities;

namespace SocialBirds.Models
{
    public class RolesAndRightsModel
    {
        public List<CPRole> Roles { get; set; }
        public List<CPMenuNavigation> AllMenuItems { get; set; }
        public List<CPRight> AllRights { get; set; }
        public List<CPRight> SelectedRights { get; set; }
        public int SelectedRoleID { get; set; }
    }
}