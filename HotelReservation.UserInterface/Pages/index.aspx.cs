using HotelReservation.Business.Concrete;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation.UserInterface
{
    public partial class index : System.Web.UI.Page
    {
         EFRoomManagementBLL _roomManagementBLL = new EFRoomManagementBLL();
         EFRoomTypeManagementBLL _roomTypeManagementBLL = new EFRoomTypeManagementBLL();
         EFPriceRatioManagementBLL _priceRatioManagementBLL = new EFPriceRatioManagementBLL();
         EFResCusRoomManagementBLL _resCusRoomManagementBLL = new EFResCusRoomManagementBLL();
         EFCustomerManagementBLL _customerManagementBLL = new EFCustomerManagementBLL();
         EFReservationTypeManagementBLL _reservationTypeManagementBLL = new EFReservationTypeManagementBLL();

        int roomFor1People;
        int roomFor2People;
        int roomFor3People;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoomTypeFill();
                ReservationTypeFill();
                PersonCountFill();
            }
            //lblEmptyRoom.Text = "";
        }
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

        protected void drpPersonCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Rooms> reservedRooms = new List<Rooms>();
            List<Rooms> emptyRooms = _roomManagementBLL.GetEmptyRoomByRoomType(Guid.Parse(drpRoomType.SelectedValue), DateTime.Parse(datepicker1.Value), DateTime.Parse(datepicker1.Value),_customerManagementBLL.GetByCivilizationNumber("0"));

            int bookingRoomCount = BookingRoomCountCalculate(Convert.ToInt32(drpPersonCount.SelectedValue), out roomFor1People, out roomFor2People, out roomFor3People);

            if (emptyRooms.Count < bookingRoomCount)
            {
                lblEmptyRoom.Text = "Üzgünüm, seçtiğiniz tarih aralığında " + drpPersonCount.SelectedValue + " kişinin konaklayabileceği kadar boş odamız bulunmamaktadır.";
                lblEmptyRoom.ForeColor = Color.Red;
            }
            else
            {
                string roomNumbers = "";
                foreach (var room in emptyRooms)
                {
                    reservedRooms.Add(room);
                    roomNumbers += room.RoomNumber;
                    if (reservedRooms.Count == bookingRoomCount)
                        break;
                    roomNumbers += ", ";
                }
                decimal totalReservationPrice = ReservationTotalPriceCalculate(DateTime.Parse(datepicker1.Value), DateTime.Parse(datepicker1.Value), Convert.ToInt32(drpPersonCount.SelectedValue));
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
        private decimal ReservationTotalPriceCalculate(DateTime _startDate, DateTime _endDate, int personCount)
        {
            TimeSpan totalDay = _endDate.AddDays(1) - _startDate;
            int totalDayCount = Convert.ToInt32(totalDay.TotalDays);
            int weekendDaysCount = WeekendDaysCountCalculate(_startDate, _endDate);
            decimal onePeopleRoomPrice = RoomPriceCalculate(roomFor1People, totalDayCount, weekendDaysCount, "1 Kişi");
            decimal twoPeopleRoomPrice = RoomPriceCalculate(roomFor2People, totalDayCount, weekendDaysCount, "2 Kişi");
            decimal threePeopleRoomPrice = RoomPriceCalculate(roomFor3People, totalDayCount, weekendDaysCount, "3 Kişi");
            return onePeopleRoomPrice + twoPeopleRoomPrice + threePeopleRoomPrice;
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

        private decimal RoomPriceCalculate(int roomCapacity, int totalDayCount, int weekendDaysCount, string priceRatioName)
        {
            return
            (
             Convert.ToDecimal(roomCapacity) *
            (Convert.ToDecimal(totalDayCount) - weekendDaysCount) *
            _roomTypeManagementBLL.GetByRoomTypeID(Guid.Parse(drpRoomType.SelectedValue)).RoomTypePrice *
             Convert.ToDecimal(_priceRatioManagementBLL.GetByPriceRatioName(priceRatioName).PriceRatio)
             )
             +
             (
             Convert.ToDecimal(roomCapacity) *
             Convert.ToDecimal(weekendDaysCount) *
             _roomTypeManagementBLL.GetByRoomTypeID(Guid.Parse(drpRoomType.SelectedValue)).RoomTypePrice *
             Convert.ToDecimal(_priceRatioManagementBLL.GetByPriceRatioName(priceRatioName).PriceRatio) *
             Convert.ToDecimal(_priceRatioManagementBLL.GetByPriceRatioName("Hafta Sonu").PriceRatio)
             );
        }
    }
}