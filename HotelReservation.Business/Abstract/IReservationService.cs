using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IReservationService
    {
         void Add(Reservations reservation);
         void Update(Reservations reservation);
    }
}
