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
    public class EFRoomTypeManagementBLL : IRoomTypeService
    {
        EFRoomTypeManagementDAL _roomTypeManagementDAL = new EFRoomTypeManagementDAL();
        //private readonly IRoomTypeManagementDAL _roomTypeManagementDAL;

        //public EFRoomTypeManagementBLL(IRoomTypeManagementDAL roomTypeManagementDAL)
        //{
        //    _roomTypeManagementDAL = roomTypeManagementDAL;
        //}

        public ICollection<RoomTypes> GetAll()
        {
            return _roomTypeManagementDAL.GetAll();
        }

        public RoomTypes GetByRoomTypeID(Guid roomTypeID)
        {
             return _roomTypeManagementDAL.Get(x => x.RoomTypeID == roomTypeID);
        }
    }
}
