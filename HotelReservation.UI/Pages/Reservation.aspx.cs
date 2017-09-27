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
     public partial class RoomTypeSelection : System.Web.UI.Page
     {
          EFUserManagementBLL _userManagememtBLL = new EFUserManagementBLL();
          EFRoomManagementBLL _roomManagementBLL = new EFRoomManagementBLL();
          EFRoomTypeManagementBLL _roomTypeManagementBLL = new EFRoomTypeManagementBLL();
          EFPriceRatioManagementBLL _priceRatioManagementBLL = new EFPriceRatioManagementBLL();
          EFResCusRoomManagementBLL _resCusRoomManagementBLL = new EFResCusRoomManagementBLL();
          EFCustomerManagementBLL _customerManagementBLL = new EFCustomerManagementBLL();
          EFReservationManagementBLL _reservationManagementBLL = new EFReservationManagementBLL();
          EFReservationTypeManagementBLL _reservationTypeManagementBLL = new EFReservationTypeManagementBLL();

          List<Rooms> reservedRooms = new List<Rooms>();
          List<Rooms> emptyRooms = new List<Rooms>();

          int roomFor1People;
          int roomFor2People;
          int roomFor3People;

          private void RoomTypeFill()
          {
               drpRoomType.DataSource = _roomTypeManagementBLL.GetAll();
               drpRoomType.DataTextField = "Description";
               drpRoomType.DataValueField = "RoomTypeID";
               drpRoomType.DataBind();
          }
          private void ReservationTypeFill()
          {
               drpReservationType.DataSource = _reservationTypeManagementBLL.GetAll();
               drpReservationType.DataTextField = "Description";
               drpReservationType.DataValueField = "ReservationTypeID";
               drpReservationType.DataBind();
          }
          private void PersonCountFill()
          {
               Dictionary<string, int> personCount = new Dictionary<string, int>();
               personCount.Add("1 Kişi", 1);
               personCount.Add("2 Kişi", 2);
               personCount.Add("3 Kişi", 3);
               personCount.Add("4 Kişi", 4);
               personCount.Add("5 Kişi", 5);
               personCount.Add("6 Kişi", 6);
               personCount.Add("7 Kişi", 7);

               drpPersonCount.DataSource = personCount;
               drpPersonCount.DataTextField = "key";
               drpPersonCount.DataValueField = "value";
               drpPersonCount.DataBind();
          }

          protected void Page_Load(object sender, EventArgs e)
          {
               if (!IsPostBack)
               {
                    RoomTypeFill();
                    ReservationTypeFill();
                    PersonCountFill();
               }
               lblEmptyRoom.Text = "";
          }

          protected void drpPersonCount_SelectedIndexChanged(object sender, EventArgs e)
          {
               int bookingRoomCount = BookingRoomCountCalculate(Convert.ToInt32(drpPersonCount.SelectedValue), out roomFor1People, out roomFor2People, out roomFor3People);

               emptyRooms = _roomManagementBLL.GetEmptyRoomByRoomType(Guid.Parse(drpRoomType.SelectedValue), DateTime.Parse(dtpStartDate.Value), DateTime.Parse(dtpEndDate.Value), _customerManagementBLL.GetByCivilizationNumber("0"));

               if (emptyRooms.Count < bookingRoomCount)
               {
                    lblEmptyRoom.Text = "Üzgünüm, seçtiğiniz tarih aralığında " + drpPersonCount.SelectedValue + " kişinin konaklayabileceği kadar boş odamız bulunmamaktadır.";
                    lblEmptyRoom.ForeColor = Color.Red;
               }
               else
               {
                    string roomNumbers = "";
                    reservedRooms = CreateReservedRooms(emptyRooms);
                    foreach (var room in reservedRooms)
                         roomNumbers += room.RoomNumber.ToString() + " ";

                    decimal totalReservationPrice = ReservationTotalPriceCalculate(DateTime.Parse(dtpStartDate.Value), DateTime.Parse(dtpEndDate.Value), Convert.ToInt32(drpPersonCount.SelectedValue),Guid.Parse(drpReservationType.SelectedValue));

                    lblEmptyRoom.Text = roomNumbers + " numaralı odalar sizin için rezerve edilebilir. Konaklama ücretiniz toplam " + Convert.ToInt32(totalReservationPrice) + " TL olacaktır. Devam etmek için üye girişi yapınız.";
               }
          }

          private int BookingRoomCountCalculate(int personCount, out int RoomFor1People, out int RoomFor2People, out int RoomFor3People)
          {
               if (personCount % 3 == 0)
               {
                    RoomFor1People = 0;
                    RoomFor2People = 0;
                    RoomFor3People = personCount / 3;
               }
               else if (personCount % 3 == 1)
               {
                    RoomFor1People = 1;
                    RoomFor2People = 0;
                    RoomFor3People = personCount / 3;
               }
               else
               {
                    RoomFor1People = 0;
                    RoomFor2People = 1;
                    RoomFor3People = personCount / 3;
               }
               return RoomFor1People + RoomFor2People + RoomFor3People;
          }

          private List<Rooms> CreateReservedRooms(List<Rooms> emptyRooms)
          {
               int bookingRoomCount = BookingRoomCountCalculate(Convert.ToInt32(drpPersonCount.SelectedValue), out roomFor1People, out roomFor2People, out roomFor3People);

               List<Rooms> reservedRooms = new List<Rooms>();
               foreach (var room in emptyRooms)
               {
                    reservedRooms.Add(room);
                    if (reservedRooms.Count == bookingRoomCount)
                         break;
               }
               return reservedRooms;
          }

          #region PriceCalculate

          private decimal ReservationTotalPriceCalculate(DateTime _startDate, DateTime _endDate, int personCount, Guid reservationTypeID)
          {
               TimeSpan totalDay = _endDate.AddDays(1) - _startDate;
               int totalDayCount = Convert.ToInt32(totalDay.TotalDays);
               int weekendDaysCount = WeekendDaysCountCalculate(_startDate, _endDate);

               decimal onePeopleRoomPrice = RoomPriceCalculate(roomFor1People, totalDayCount, weekendDaysCount, "1 Kişi");
               decimal twoPeopleRoomPrice = RoomPriceCalculate(roomFor2People, totalDayCount, weekendDaysCount, "2 Kişi");
               decimal threePeopleRoomPrice = RoomPriceCalculate(roomFor3People, totalDayCount, weekendDaysCount, "3 Kişi");
               decimal reservationTotalServicePrice = ReservationTotalServicePriceCalculate(totalDayCount, reservationTypeID);

               return onePeopleRoomPrice + twoPeopleRoomPrice + threePeopleRoomPrice + reservationTotalServicePrice;
          }

          private int WeekendDaysCountCalculate(DateTime _startDate, DateTime _endDate)
          {
               int weekendDaysCount = 0;
               do
               {
                    if (_startDate.DayOfWeek == DayOfWeek.Saturday
                        || _startDate.DayOfWeek == DayOfWeek.Sunday)
                         weekendDaysCount++;
                    _startDate = _startDate.AddDays(1);
               } while (_startDate <= _endDate);
               return weekendDaysCount;
          }

          private decimal RoomPriceCalculate(int roomCount, int totalDayCount, int weekendDaysCount, string priceRatioName)
          {
               return
               (
                Convert.ToDecimal(roomCount) *
               (Convert.ToDecimal(totalDayCount) - weekendDaysCount) *
               _roomTypeManagementBLL.GetByRoomTypeID(Guid.Parse(drpRoomType.SelectedValue)).RoomTypePrice *
                Convert.ToDecimal(_priceRatioManagementBLL.GetByPriceRatioName(priceRatioName).PriceRatio)
                )
                +
                (
                Convert.ToDecimal(roomCount) *
                Convert.ToDecimal(weekendDaysCount) *
                _roomTypeManagementBLL.GetByRoomTypeID(Guid.Parse(drpRoomType.SelectedValue)).RoomTypePrice *
                Convert.ToDecimal(_priceRatioManagementBLL.GetByPriceRatioName(priceRatioName).PriceRatio) *
                Convert.ToDecimal(_priceRatioManagementBLL.GetByPriceRatioName("Hafta Sonu").PriceRatio)
                );
          }

          private decimal ReservationTotalServicePriceCalculate(int totalDayCount, Guid reservationTypeID)
          {
               return totalDayCount * _reservationTypeManagementBLL.GetByReservationTypeID(reservationTypeID).ServicePrice;
          }

          #endregion

          protected void continue_Click(object sender, EventArgs e)
          {
               //sessiondaki ? empty rooms ile buradakini karşılaştır aynı değilse uyarı ver.
               emptyRooms = _roomManagementBLL.GetEmptyRoomByRoomType(Guid.Parse(drpRoomType.SelectedValue), DateTime.Parse(dtpStartDate.Value), DateTime.Parse(dtpEndDate.Value), _customerManagementBLL.GetByCivilizationNumber("0"));

               reservedRooms = CreateReservedRooms(emptyRooms);

               Reservations newReservation = new Reservations();
               newReservation.ReservationID = Guid.NewGuid();
               newReservation.ReservationTypeID = Guid.Parse(drpReservationType.SelectedValue);
               newReservation.UserID = _userManagememtBLL.GetByUserName("Reserved").UserID;
               newReservation.ReservationDate = DateTime.Now;
               newReservation.StartDate = DateTime.Parse(dtpStartDate.Value);
               newReservation.EndDate = DateTime.Parse(dtpEndDate.Value);
               newReservation.PersonCount = Convert.ToByte(drpPersonCount.SelectedValue);

               _reservationManagementBLL.Add(newReservation);

               foreach (var room in reservedRooms)
               {
                    ResCusRooms newResCusRooms = new ResCusRooms();
                    newResCusRooms.ReservationID = newReservation.ReservationID;
                    newResCusRooms.CustomerID = _customerManagementBLL.GetByCivilizationNumber("0").CustomerID;
                    newResCusRooms.RoomNumber = room.RoomNumber;

                    _resCusRoomManagementBLL.Add(newResCusRooms);
               }
               Session["reservedRooms"] = reservedRooms;
               Session["reservation"] = newReservation;
               Response.Redirect("CustomerInformation.aspx");
          }
     }
}