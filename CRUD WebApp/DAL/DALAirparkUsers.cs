using System.Collections.Generic;
using System.Data.SqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALAirparkUsers
    {
        public int CreateNewUser(PropertiesUsers user)
        {            
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> lstParameter = new List<SqlParameter>();                        
            lstParameter.Add(new SqlParameter("@email", user.Email));
            lstParameter.Add(new SqlParameter("@givenName", user.UserGivenName));
            lstParameter.Add(new SqlParameter("@familyName", user.UserFamilyName));            

            return sqlHelper.executeSP<int>(lstParameter, "InsertNewUser");
        }

        public List<PropertiesUsers> getAllUsers()
        {
            List<PropertiesUsers> userList = new List<PropertiesUsers>();
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> parameters = new List<SqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "getAllUsers");


            PropertiesUsers user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PropertiesUsers(Convert.ToInt32(drow[0].ToString()) , drow[1].ToString(), drow[2].ToString(), drow[3].ToString(), drow[4].ToString());
                userList.Add(user);
            }

            return userList;
        }

        public List<PropertiesUsers> getUser(string searchUser)
        {
            List<PropertiesUsers> userList = new List<PropertiesUsers>();
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@GivenName", searchUser));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectUsersByName");

            PropertiesUsers user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PropertiesUsers(Convert.ToInt32(drow[0].ToString()) , drow[1].ToString(), drow[2].ToString(), drow[3].ToString(), drow[4].ToString());
                userList.Add(user);
            }

            return userList;
        }

        public int DeleteUser(int userID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@id", userID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteUser");                
        }

        public List<PropertiesUsers> GetUserById(int userID)
        {
            List<PropertiesUsers> userList = new List<PropertiesUsers>();
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@id", userID));
            var resultSet = sqlHelper.executeSP<DataSet>(lstParameter, "SelectUserByID");

            PropertiesUsers user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PropertiesUsers(Convert.ToInt32(drow[0].ToString()), drow[1].ToString(), drow[2].ToString(), drow[3].ToString(), drow[4].ToString());
                userList.Add(user);
            }

            return userList;
        }

        public void UpdateUser(PropertiesUsers user)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            lstParameter.Add(new SqlParameter("@id", user.UserID));
            lstParameter.Add(new SqlParameter("@email", user.Email));
            lstParameter.Add(new SqlParameter("@givenName", user.UserGivenName));
            lstParameter.Add(new SqlParameter("@familyName", user.UserFamilyName));
            
            sqlHelper.executenonquery(lstParameter, "UpdateUserInfo");
        }
    }
}
