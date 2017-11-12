using SocialBirds.DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBirds.DAL.Services
{
    public class UserServices
    {
        #region Define as Singleton
        private static UserServices _Instance;

        public static UserServices Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserServices();
                }

                return (_Instance);
            }
        }

        private UserServices()
        {
        }
        #endregion

        public User Login(string email, string password)
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                var ppSql = PetaPoco.Sql.Builder.Select("*").From("Users").Where("Email = @0 AND Password = @1 AND IsActive = 1", email, password);
                return context.Fetch<User>(ppSql).FirstOrDefault();
            }
        }

        public User Register(User user)
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                context.Insert(user);
                return user;
            }
        }
        public List<Role> GetAllRoles()
        {
            using (var context =  DataContextHelper.GetPPDataContext())
            {
                List<Role> Roles = new List<Role>();

                //context.Execute("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                Roles = context.Fetch<Role>("Select * From Roles").ToList();

                //context.Execute("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                return Roles;
            }
        }
        public List<Right> GetAllRights()
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                return context.Fetch<Right>("Select * From Rights where ApplicationID= 6").ToList();
            }
        }
        public List<CPMenuNavigation> GetAllMenutItems()
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                var ppSql = PetaPoco.Sql.Builder.Select(@"*")
                            .From("CPMenuNavigation");

                return context.Fetch<CPMenuNavigation>(ppSql).ToList();
            }
        }
        public List<Right> GetAllRightsByRole(int roleID)
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                List<Right> Rights = new List<Right>();

                //context.Execute("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                Rights = context.Fetch<Right>("Select * From Rights R Inner Join RolesRights RR On R.RightID = RR.RightID Where RR.RoleID = @0", roleID).ToList();

                //context.Execute("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                return Rights;
            }
        }
        public void GrantRightToRole(int rightID, int roleID)
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                RolesRight ur = new RolesRight();
                ur.RoleID = roleID;
                ur.RightID = rightID;
                context.Insert(ur);
            }
        }
        public void DenyRightToRole(int rightID, int roleID)
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                context.Execute("Delete From RolesRights Where RightID = @0 And RoleID = @1", rightID, roleID);
            }
        }
        public List<Right> GetUserRights(int userID)
        {
            using (var context = DataContextHelper.GetPPDataContext())
            {
                List<Right> Rights = new List<Right>();

                //context.Execute("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                var sql = PetaPoco.Sql.Builder
                    .Select("RI.*")
                    .From("UserRoles UR")
                    .InnerJoin("Roles R").On("UR.RoleID = R.RoleID")
                    .InnerJoin("RolesRights RR").On("R.RoleID = RR.RoleID")
                    .InnerJoin("Rights RI").On("RI.RightID = RR.RightID")
                    .Where(" UR.USerID = @0",  userID);

                Rights = context.Fetch<Right>(sql).ToList();

               // context.Execute("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                return Rights;
            }
        }
    }
}
