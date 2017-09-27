using HotelReservation.Business.Concrete;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation.UI.Pages
{
    public partial class UserUpdate : System.Web.UI.Page
    {
        EFUserManagementBLL _userManagementBLL = new EFUserManagementBLL();
        EFPasswordManagementBLL _passwordManagementBLL = new EFPasswordManagementBLL();
        Users updateUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                updateUser = (Users)Session["user"];
                if (!IsPostBack)
                {
                    Fill();
                }
            }
        }

        protected void userUpdate_Click(object sender, EventArgs e)
        {
                updateUser.FirstName = txtFirstName.Value;
                updateUser.LastName = txtLastName.Value;
                updateUser.Email = txtEmail.Value;
                updateUser.Telephone = txtTelephone.Value;

                Passwords oldPassword = updateUser.Password.Where(x => x.IsActive == true).FirstOrDefault();
                oldPassword.IsActive = false;

                Passwords newPassword = new Passwords();
                newPassword.PasswordID = Guid.NewGuid();
                newPassword.UserID = updateUser.UserID;
                newPassword.Password = txtPassword.Value;
                newPassword.IsActive = true;

                _userManagementBLL.Update(updateUser);
                _passwordManagementBLL.Update(oldPassword);
                _passwordManagementBLL.Add(newPassword);

                Session["user"] = updateUser;
        }

        void Fill()
        {
            txtFirstName.Value = updateUser.FirstName;
            txtLastName.Value = updateUser.LastName;
            txtEmail.Value = updateUser.Email;
            txtTelephone.Value = updateUser.Telephone;
            txtPassword.Value = updateUser.Password.Where(x => x.IsActive == true).FirstOrDefault().Password;
        }
    }
}