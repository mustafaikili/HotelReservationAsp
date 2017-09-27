using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class ResCusRooms : IEntity
     {
          public Guid ReservationID { get; set; }
          public Guid CustomerID { get; set; }
          public int RoomNumber { get; set; }

          //Navigation Properties
          public virtual Reservations Reservation { get; set; }
          public virtual Customers Customer { get; set; }
          public virtual Rooms Room { get; set; }
     }
}
