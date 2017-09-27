using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IUserService
    {
        void Add(Users user);
        void Update(Users user);
        Users GetByUserName(string userName);
        Users GetByCivilizationNumber(string civilizationNumber);
    }
}
