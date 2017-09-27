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
    public class EFReservationTypeManagementBLL : IReservationTypeService
    {
        EFReservationTypeManagementDAL _reservationTypeManagementDAL = new EFReservationTypeManagementDAL();
        //private readonly IReservationTypeManagementDAL _reservationTypeManagementDAL;

        //public EFReservationTypeManagementBLL(IReservationTypeManagementDAL reservationTypeManagementDAL)
        //{
        //    _reservationTypeManagementDAL = reservationTypeManagementDAL;
        //}

        public ICollection<ReservationTypes> GetAll()
        {
            return _reservationTypeManagementDAL.GetAll();
        }

        public ReservationTypes GetByReservationTypeID(Guid reservationTypeID)
        {
             return _reservationTypeManagementDAL.Get(x => x.ReservationTypeID == reservationTypeID);
        }
    }
}
