using SocialBirds.DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SocialBirds.DAL.Services
{
    public static class DataContextHelper
    {
        public static SocialBirdsRepository GetCPDataContext(bool enableAutoSelect = true)
        {
            return (GetNewDataContext("CPConnectionString", enableAutoSelect));
        }

        public static SocialBirdsRepository GetPPDataContext(bool enableAutoSelect = true)
        {
            return (GetNewDataContext("PPConnectionString", enableAutoSelect));
        }

        private static SocialBirdsRepository GetNewDataContext(string connectionStringName, bool enableAutoSelect)
        {
            SocialBirdsRepository repository = new SocialBirdsRepository(connectionStringName);
            repository.EnableAutoSelect = enableAutoSelect;
            return (repository);
        }
        private static SocialBirdsRepository GetNewDataContext(string connectionString, string providerName, bool enableAutoSelect)
        {
            SocialBirdsRepository repository = new SocialBirdsRepository(connectionString, providerName);
            repository.EnableAutoSelect = enableAutoSelect;
            return (repository);
        }

        public static void EncryptConnString()
        {

            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
            ConfigurationSection section = config.GetSection("connectionStrings");
            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                config.Save();
            }
        }
    }
}
