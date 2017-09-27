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
     public class EFUserManagementBLL : IUserService
     {
         EFUserManagementDAL _userManagementDAL = new EFUserManagementDAL();
          //private readonly IUserManagementDAL _userManagementDAL;

          //public EFUserManagementBLL(IUserManagementDAL userManagementDAL)
          //{
          //    _userManagementDAL = userManagementDAL;
          //}

          public void Add(Users user)
          {
               _userManagementDAL.Add(user);
          }

          public void Update(Users user)
          {
               _userManagementDAL.Update(user);
          }

          public Users GetByUserName(string userName)
          {
               return _userManagementDAL.Get(x => x.UserName == userName);
          }

          public Users GetByCivilizationNumber(string civilizationNumber)
          {
              return _userManagementDAL.Get(x => x.CivilizationNumber == civilizationNumber);
          }
     }
}
