using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concreate.EntityFramework;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Concrete.EntityFramework.DALManagement
{
     public class EFCustomerManagementDAL : EFEntityRepositoryBase<HotelReservationDBContext,Customers> , ICustomerManagementDAL
     {
     }
}
