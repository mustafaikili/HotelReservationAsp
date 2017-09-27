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
    public class EFRoomImageManagementBLL : IRoomImageService
    {
        EFRoomImageManagementDAL _roomImageManagementDAL = new EFRoomImageManagementDAL();
        //private readonly IRoomImageManagementDAL _roomImageManagementDAL;

        //public EFRoomImageManagementBLL(IRoomImageManagementDAL roomImageManagementDAL)
        //{
        //    _roomImageManagementDAL = roomImageManagementDAL;
        //}
    }
}
