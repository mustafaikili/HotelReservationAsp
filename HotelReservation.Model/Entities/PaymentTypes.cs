using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class PaymentTypes : IEntity
     {
          public Guid PaymentTypeID { get; set; }
          public string PaymentType { get; set; }

          public Guid? CreatedBy { get; set; }
          public DateTime? CreatedDate { get; set; }
          public Guid? LastModifiedBy { get; set; }
          public DateTime? LastModifiedDate { get; set; }
          public bool? IsActive { get; set; }

          //Navigation Properties
          public virtual ICollection<Payments> Payment { get; set; }
     }
}
