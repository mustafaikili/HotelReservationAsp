using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class Reservations : IEntity
    {
        public Guid ReservationID { get; set; }
        public Guid ReservationTypeID { get; set; }
        public Guid UserID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte PersonCount { get; set; }

        public DateTime? CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        //Navigation Properties
        public virtual Users User { get; set; }
        public virtual ReservationTypes ReservationType { get; set; }
        public virtual ICollection<ResCusRooms> ResCusRoom { get; set; }
    }
}
