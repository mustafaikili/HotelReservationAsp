using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class ReservationTypes : IEntity
    {
        public Guid ReservationTypeID { get; set; }
        public string ReservationTypeName { get; set; }
        public decimal ServicePrice { get; set; }
        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        //Navigation Properties
        public virtual ICollection<Reservations> Reservation { get; set; }
    }
}
