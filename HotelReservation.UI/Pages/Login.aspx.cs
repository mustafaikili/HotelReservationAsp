using HotelReservation.Business.Concrete;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation.UI.Pages
{
     public partial class Login : System.Web.UI.Page
     {
          EFUserManagementBLL _userManagementBLL = new EFUserManagementBLL();

          protected void Page_Load(object sender, EventArgs e)
          {
               if (!IsPostBack)
               {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
               }
          }

          protected void btnLogin_Click(object sender, EventArgs e)
          {
               string userName = txtUserName.Value;
               string password = txtPassword.Value;

               Users user = _userManagementBLL.GetByUserName(userName);

               if (user == null || user.Password.Where(x => x.IsActive == true).FirstOrDefault().Password != password)
               {
                    lblInfo.Text = "Kullanıcı Adı veya Parola hatalı !!!";
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Visible = true;
               }
               else
               {
                    Session["User"] = user;
                    Response.Redirect("Anasayfa.aspx");
               }
          }

          protected void LinkButton1_Click(object sender, EventArgs e)
          {
              Response.Redirect("SignUp.aspx");
          }
     }
}