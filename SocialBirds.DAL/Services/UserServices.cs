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
    }
}
