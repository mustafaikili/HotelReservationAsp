using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class Payments : IEntity
     {
          public Guid PaymentID { get; set; }
          public Guid ReservationID { get; set; }
          public Guid PaymentTypeID { get; set; }
          public decimal TotalPrice { get; set; }
          public string Description { get; set; }

          public Guid? CreatedBy { get; set; }
          public DateTime? CreatedDate { get; set; }
          public Guid? LastModifiedBy { get; set; }
          public DateTime? LastModifiedDate { get; set; }
          public bool? IsActive { get; set; }

          //Navigation Properties
          public virtual PaymentTypes PaymentType { get; set; }
          public virtual Reservations Reservation { get; set; }
     }
}
