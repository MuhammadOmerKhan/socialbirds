using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace SocialBirds.DAL.Entities
{
    public class EntitiesDetail
    {
        [ResultColumn]
        public string PrimaryKey { get; set; }
        [ResultColumn]
        public short EntityID { get; set; }
        [ResultColumn]
        public string TableName { get; set; }
    }
    public class SessionUserEntity
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DisplayPictureURL { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string SessionID { get; set; }
    }
}
