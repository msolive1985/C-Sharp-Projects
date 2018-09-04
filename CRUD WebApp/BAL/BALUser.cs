using System;
using DAL;
using PROP;
using System.Collections.Generic;
namespace BAL
{
    public class BALUser
    {
        public int CreateNewUser(PropertiesUsers user)
        {
            if (string.IsNullOrEmpty(user.UserGivenName) || string.IsNullOrEmpty(user.UserFamilyName) || string.IsNullOrEmpty(user.Email))
            {
                return -1;
            }
            else
            {
                DALAirparkUsers dalUser = new DALAirparkUsers();
                return dalUser.CreateNewUser(user);
            }
        }

        public List<PropertiesUsers> getUser(string searchUser)
        {
            DALAirparkUsers dalUser = new DALAirparkUsers();

            if (string.IsNullOrEmpty(searchUser))
            {
                return dalUser.getAllUsers();
            }
            else
            {
                return dalUser.getUser(searchUser);
            }
        }

        public int deleteUser(string stringUserID)
        {
            int userID;
            DALAirparkUsers dalUser = new DALAirparkUsers();
            int.TryParse(stringUserID, out userID);

            if (userID == 0)
            {
                return 0;
            }
            else
            {
                return dalUser.DeleteUser(userID);
            }
        }

        public List<PropertiesUsers> getUserByID(string stringUserID)
        {
            int userID;
            DALAirparkUsers dalUser = new DALAirparkUsers();
            int.TryParse(stringUserID, out userID);
            if (userID == 0)
            {
                return null;
            }
            else
            {
                return dalUser.GetUserById(userID);
            }
        }

        public bool updateUser(PropertiesUsers user)
        {
            if (string.IsNullOrEmpty(user.UserGivenName) || string.IsNullOrEmpty(user.UserFamilyName) || string.IsNullOrEmpty(user.Email))
            {
                return false;
            }
            else
            {
                DALAirparkUsers dalUser = new DALAirparkUsers();
                dalUser.UpdateUser(user);
                return true;
            }
        }
    }
}
