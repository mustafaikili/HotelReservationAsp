using HotelReservation.Business.Concrete;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation.UI.Pages
{
    public partial class Signup : System.Web.UI.Page
    {
        EFUserManagementBLL _userManagementBLL = new EFUserManagementBLL();
        EFPasswordManagementBLL _passwordManagementBLL = new EFPasswordManagementBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlClear();
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Users getUserCivilizationNumber = _userManagementBLL.GetByCivilizationNumber(txtCivilizationNumber.Value);
            Users getUserUserName= _userManagementBLL.GetByUserName(txtUserName.Value);
            if (getUserCivilizationNumber != null || getUserUserName !=null)
            {
                lblInfo.Text = "Girdiğiniz kimlik numarası veya username daha önce kullanılmıştır.";
            }
            else
            {
                Users newUser = new Users();

                newUser.UserID = Guid.NewGuid();
                newUser.CivilizationNumber = txtCivilizationNumber.Value;
                newUser.UserName = txtUserName.Value;
                newUser.FirstName = txtFirstName.Value;
                newUser.LastName = txtLastName.Value;
                newUser.IsActive = true;

                _userManagementBLL.Add(newUser);

                Passwords newPassword = new Passwords();

                newPassword.PasswordID = Guid.NewGuid();
                newPassword.UserID = newUser.UserID;
                newPassword.Password = txtPassword.Value;
                newPassword.IsActive = true;

                _passwordManagementBLL.Add(newPassword);

                lblInfo.Text = "Kayıt İşlemi Başarılı !";
                lblInfo.ForeColor = Color.Green;
                lblInfo.Visible = true;
                ControlClear();

                LinkButton1.Visible = true;
            }
        }

        void ControlClear()
        {
            txtCivilizationNumber.Value = "";
            txtUserName.Value = "";
            txtFirstName.Value = "";
            txtLastName.Value = "";
            txtPassword.Value = "";
            txtPasswordAgain.Value = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}