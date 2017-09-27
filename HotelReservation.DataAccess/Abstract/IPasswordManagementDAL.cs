using HotelReservation.Core.DataAccess;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
     public interface IPasswordManagementDAL : IEntityRepository<Passwords>
     {
     }
}
