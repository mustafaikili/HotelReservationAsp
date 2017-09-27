using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
     public interface IRoomService
     {
          List<Rooms> TakeReservedRooms(List<Rooms> emptyRooms, Customers customer);
          List<Rooms> GetEmptyRoomByRoomType(Guid _roomTypeID, DateTime _startDate, DateTime _endDate, Customers customer);
     }
}
