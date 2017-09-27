using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.DALManagement;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Concrete
{
    public class EFReservationManagementBLL : IReservationService
    {
        EFReservationManagementDAL _reservationManagementDAL = new EFReservationManagementDAL();
        //private readonly IReservationManagementDAL _reservationManagementDAL;

        //public EFReservationManagementBLL(IReservationManagementDAL reservationManagementDAL)
        //{
        //    _reservationManagementDAL = reservationManagementDAL;
        //}

        public void Add(Reservations reservation)
        {
             _reservationManagementDAL.Add(reservation);
        }

        public void Update(Reservations reservation)
        {
             _reservationManagementDAL.Update(reservation);
        }
    }
}
