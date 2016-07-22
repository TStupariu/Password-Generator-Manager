using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
        public class Identity
        {
            //THE CLASS FOR EACH INDIVIDUAL IDENTITY
            public int ID;
            public string website;
            public string username;
            public string password;


            public void Init_Identity(int NID, string NWebsite, string NUsername, string NPassword)
            {
                //INITIALIZER FOR THE IDENTITY
                ID = NID;
                website = NWebsite;
                username = NUsername;
                password = NPassword;
            }


            //SETTERS
            public void setID(int NID)
            {
                ID = NID;
            }
            public void setWebsite(string NWebsite)
            {
                website = NWebsite;
            }
            public void setUsername(string NUsername)
            {
                username = NUsername;
            }
            public void setPassword(string NPassword)
            {
                password = NPassword;
            }
            //GETTERS
            public int getID()
            {
                return ID;
            }
            public string getWebsite()
            {
                return website;
            }
            public string getUsername()
            {
                return username;
            }
            public string getPassword()
            {
                return password;
            }
        }

    
}
