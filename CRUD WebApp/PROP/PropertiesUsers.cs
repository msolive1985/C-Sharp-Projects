using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PropertiesUsers
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string UserGivenName { get; set; }
        public string UserFamilyName { get; set; }
        public string CreatedDateTime { get; set; }
        public PropertiesUsers()
        {

        }

        public PropertiesUsers(int userID, string email, string userGivenName, string userFamilyName, string createdDateTime)
        {
            this.UserID = userID;
            this.Email = email;
            this.UserGivenName = userGivenName;
            this.UserFamilyName = userFamilyName;
            this.CreatedDateTime = createdDateTime;
        }        
    }
}
