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
     public partial class CustomerInformation : System.Web.UI.Page
     {
          EFCustomerManagementBLL _customerManagementBLL = new EFCustomerManagementBLL();
          EFReservationManagementBLL _reservationManagementBLL = new EFReservationManagementBLL();
          EFResCusRoomManagementBLL _resCusRoomManagementBLL = new EFResCusRoomManagementBLL();

          Reservations newReservation;
          List<Rooms> reservedRooms;
          Users user;

          protected void Page_Load(object sender, EventArgs e)
          {
               newReservation = (Reservations)Session["reservation"];
               user = (Users)Session["user"];

               for (int i = 0; i < newReservation.PersonCount; i++)
               {
                    Panel panel = new Panel();
                    panel.ID = "panel" + (i + 1);
                    panel.Width = 250;
                    panel.Attributes.Add("runat", "server");
                    panel.Style.Add("margin-left", "70px");
                    panel.Style.Add("margin-bottom", "25px;");
                    panel.BorderWidth = 2;
                    panel.BorderStyle = BorderStyle.Dotted;
                    panel.BorderColor = System.Drawing.Color.White;
                    panel.Style.Add("padding-top", "20px");
                    panel.Style.Add("margin-top", "5px");

                    Label lblTC = new Label();
                    Label lblFirstName = new Label();
                    Label lblLastName = new Label();
                    lblTC.ID = "lblTC" + (i + 1);
                    lblFirstName.ID = "lblFirstName" + (i + 1);
                    lblLastName.ID = "lblLastName" + (i + 1);
                    lblTC.Text = "TC : ";
                    lblFirstName.Text = "İsim : ";
                    lblLastName.Text = "Soyisim : ";
                    lblTC.Width = 60;
                    lblFirstName.Width = 60;
                    lblLastName.Width = 60;
                    lblTC.ForeColor = System.Drawing.Color.White;
                    lblFirstName.ForeColor = System.Drawing.Color.White;
                    lblLastName.ForeColor = System.Drawing.Color.White;


                    TextBox txtTC = new TextBox();
                    TextBox txtFirstName = new TextBox();
                    TextBox txtLastName = new TextBox();
                    txtTC.ID = "txtTC" + (i + 1);
                    txtFirstName.ID = "txtFirstName" + (i + 1);
                    txtLastName.ID = "txtLastName" + (i + 1);

                    txtTC.Width = 140;
                    txtFirstName.Width = 140;
                    txtLastName.Width = 140;

                    txtTC.Attributes.Add("runat", "server");
                    txtFirstName.Attributes.Add("runat", "server");
                    txtLastName.Attributes.Add("runat", "server");

                    Label lblCustomers = new Label();
                    lblCustomers.ID = "lblCustomers" + (i + 1);
                    lblCustomers.Text = (i + 1) + ". Müşteri Bilgileri";
                    lblCustomers.ForeColor = System.Drawing.Color.White;

                    customers.Controls.Add(lblCustomers);
                    customers.Controls.Add(panel);
                    panel.Controls.Add(lblTC);
                    panel.Controls.Add(txtTC);
                    panel.Controls.Add(lblFirstName);
                    panel.Controls.Add(txtFirstName);
                    panel.Controls.Add(lblLastName);
                    panel.Controls.Add(txtLastName);

               }

               Label lbl = new Label();
               lbl.ID = "lblError";
               lbl.Visible = false;
               lbl.Text = "";
               lbl.Style.Add("margin-top", "20px");
               lbl.Attributes.Add("runat", "server");
               lbl.Style.Add("display", "block");
               lbl.ForeColor = System.Drawing.Color.Red;
               lbl.Style.Add("margin", "auto");

               Button btn = new Button();
               btn.ID = "btnReservation";
               btn.Width = 270;
               btn.Text = "Rezervasyonu Tamamla";
               btn.Attributes.Add("runat", "server");
               btn.Style.Add("margin-top", "20px");
               btn.Style.Add("margin", "auto");

               btn.Click += new EventHandler(btnReservation_Click);

               customers.Controls.Add(lbl);
               customers.Controls.Add(btn);
          }


          protected void btnReservation_Click(object sender, EventArgs e)
          {
               foreach (var resCusRoom in _resCusRoomManagementBLL.GetAll(_customerManagementBLL.GetByCivilizationNumber("0").CustomerID))
                    _resCusRoomManagementBLL.Delete(resCusRoom);

               reservedRooms = (List<Rooms>)Session["reservedRooms"];
               user = (Users)Session["user"];
               newReservation = (Reservations)Session["reservation"];
               newReservation.UserID = user.UserID;

               _reservationManagementBLL.Update(newReservation);

               for (int i = 1; i <= newReservation.PersonCount; i++)
               {
                    string civilizationNumber = "txtTC" + (i);
                    string firstName = "txtFirstName" + (i);
                    string lastName = "txtLastName" + (i);

                    if (Request.Form[civilizationNumber] == "" && Request.Form[firstName] == "" && Request.Form[lastName] == "")
                    {
                         Label lbl = (Label)FindControl("lblError");
                         lbl.Text = "Lütfen boş alan bırakmayınız !!!";
                         lbl.ForeColor = Color.Red;
                         lbl.Visible = true;
                    }
                    else
                    {
                         Customers newCustomer = new Customers();
                         newCustomer.CustomerID = Guid.NewGuid();
                         newCustomer.CivilizationNumber = Request.Form[civilizationNumber];
                         newCustomer.FirstName = Request.Form[firstName];
                         newCustomer.LastName = Request.Form[lastName];
                         _customerManagementBLL.Add(newCustomer);

                         ResCusRooms newResCusRoom = new ResCusRooms();
                         newResCusRoom.ReservationID = newReservation.ReservationID;
                         newResCusRoom.CustomerID = newCustomer.CustomerID;
                         newResCusRoom.RoomNumber = reservedRooms.FirstOrDefault().RoomNumber;
                         _resCusRoomManagementBLL.Add(newResCusRoom);

                         if (i%3==0)
                              reservedRooms.Remove(reservedRooms.FirstOrDefault());
                    }
               }
               Label lblMessage = (Label)FindControl("lblError");
               lblMessage.Text = "Rezervasyonunuz oluşturulmuştur.";
               lblMessage.ForeColor = Color.Green;
               lblMessage.Visible = true;
          }
     }
}