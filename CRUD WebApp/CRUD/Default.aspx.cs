using System;
using System.Web.UI;
using BAL;
using PROP;
using Logging;
using System.Collections.Generic;

namespace CRUD
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binding(null);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            BALUser balUser = new BALUser();
            
            try
            {
                PROP.PropertiesUsers user = new PROP.PropertiesUsers();                
                user.Email = txtEmail.Text;
                user.UserGivenName = txtGivenName.Text;
                user.UserFamilyName = txtFamilyName.Text;
                user.CreatedDateTime = DateTime.Now.ToString();

                int returnValue = balUser.CreateNewUser(user);
                if (returnValue == 0)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('The user was created successfully.')</script>");
                    txtEmail.Text = string.Empty;
                    txtGivenName.Text = string.Empty;
                    txtFamilyName.Text = string.Empty;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('Incorrect user Inputs.')</script>");
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BALUser balUser = new BALUser();
            try
            {
                int returnValue = balUser.deleteUser(txtDeleteID.Text);
                if (returnValue == 0)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('The user was deleted successfully.')</script>");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('User ID not found.')</script>");
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            binding(txtSearchName.Text);
        }        

        protected void btnEditUserName_Click(object sender, EventArgs e)
        {
            try
            {
                PROP.PropertiesUsers user = new PROP.PropertiesUsers();
                user.UserID = Convert.ToInt16(ddlUsers.SelectedValue);
                user.Email = txtEmailUpdate.Text;
                user.UserGivenName = txtGivenNameUpdate.Text;
                user.UserFamilyName = txtFamilyNameUpdate.Text;                

                BALUser balCountry = new BALUser();
                bool result = balCountry.updateUser(user);

                if (!result)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('Your input has invalid structure for update.')</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('The user has been updated successfully.')</script>");
                    binding(null);
                    ddlUsers.SelectedIndex = 0;
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);                                                 
            }
        }

        private void binding(string searchUser)
        {
            try
            {
                BALUser balUser = new BALUser();
                gvCountryList.DataSource = balUser.getUser(searchUser);
                gvCountryList.DataBind();
                
                ddlUsers.DataSource = balUser.getUser(null);
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataTextField = "UserID";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0,new System.Web.UI.WebControls.ListItem("-SELECT-", "-1"));
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);                                                 
            }            
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string UserGivenName = string.Empty;
            BALUser balUser = new BALUser();                      
            try
            {
                List<PropertiesUsers> puserCollection = balUser.getUserByID(ddlUsers.SelectedValue);
                if (puserCollection == null)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "message", "<script>alert('The user ID is not found.')</script>");
                }
                else
                {
                    foreach (PropertiesUsers puser in puserCollection)
                    {
                        txtEmailUpdate.Text = puser.Email;
                        txtGivenNameUpdate.Text = puser.UserGivenName;
                        txtFamilyNameUpdate.Text = puser.UserFamilyName;                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }   
        }
    }
}
