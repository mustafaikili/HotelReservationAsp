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
     public class EFRoomManagementBLL : IRoomService
     {
          EFRoomManagementDAL _roomManagementDAL = new EFRoomManagementDAL();
          //private readonly IRoomManagementDAL _roomManagementDAL;

          //public EFRoomManagementBLL(IRoomManagementDAL roomManagementDAL)
          //{
          //    _roomManagementDAL = roomManagementDAL;
          //}

          private List<Rooms> TakeReservedRooms(List<Rooms> emptyRooms, Customers customer)
          {
               foreach (var room in emptyRooms)
               {
                    foreach (var resCusRoom in room.ResCusRoom.Where(x => x.CustomerID == customer.CustomerID))
                    {
                         emptyRooms.Remove(room);
                    }
               }
               return emptyRooms;
          }

          public List<Rooms> GetEmptyRoomByRoomType(Guid _roomTypeID, DateTime _startDate, DateTime _endDate, Customers customer)
          {
               DateTime startDate = _startDate;
               DateTime endDate = _endDate;
               DateTime resStartDate;
               DateTime resEndDate;
               string roomState;
               List<Rooms> emptyRooms = new List<Rooms>();

               foreach (var room in _roomManagementDAL.GetAll(x => x.RoomTypeID == _roomTypeID))
               {
                    roomState = "empty";
                    if (room.ResCusRoom.Count == 0)
                    {
                         emptyRooms.Add(room);
                    }
                    else
                    {
                         foreach (var resCusRoom in room.ResCusRoom.Select(x => new { x.ReservationID, x.Reservation }).Distinct())
                         {
                              resStartDate = resCusRoom.Reservation.StartDate;
                              resEndDate = resCusRoom.Reservation.EndDate;
                              if (startDate == resEndDate || endDate == resStartDate)
                              {
                                   roomState = "full";
                                   break;
                              }
                              else if (DateTime.Compare(startDate, resEndDate) == 1)
                                   continue;
                              else
                              {
                                   if (DateTime.Compare(resStartDate, endDate) == 1)
                                        continue;
                                   else
                                   {
                                        roomState = "full";
                                        break;
                                   }
                              }
                         }
                         if (roomState == "empty")
                              emptyRooms.Add(room);
                    }
               }
               return TakeReservedRooms(emptyRooms, customer);
          }

          #region IRoomService Members

          List<Rooms> IRoomService.TakeReservedRooms(List<Rooms> emptyRooms, Customers customer)
          {
               throw new NotImplementedException();
          }

          #endregion
     }
}
