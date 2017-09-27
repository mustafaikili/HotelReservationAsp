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
     public class EFResCusRoomManagementBLL : IResCusRoomService
     {
          EFResCusRoomManagementDAL _resCusRoomManagementDAL = new EFResCusRoomManagementDAL();
          //private readonly IResCusRoomManagementDAL _resCusRoomManagementDAL;

          //public EFResCusRoomManagementBLL(IResCusRoomManagementDAL resCusRoomManagementDAL)
          //{
          //    _resCusRoomManagementDAL = resCusRoomManagementDAL;
          //}

          public void Add(ResCusRooms resCusRoom)
          {
               _resCusRoomManagementDAL.Add(resCusRoom);
          }

          public void Delete(ResCusRooms resCusRoom)
          {
               _resCusRoomManagementDAL.Delete(resCusRoom);
          }

          public ICollection<ResCusRooms> GetAll(Guid customerID)
          {
               return _resCusRoomManagementDAL.GetAll(x => x.CustomerID == customerID);
          }
     }
}
