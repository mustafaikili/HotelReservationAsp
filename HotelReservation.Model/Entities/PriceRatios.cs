using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class PriceRatios : IEntity
     {
          public Guid PriceRatioID { get; set; }
          public string PriceRatioName { get; set; }
          public Single PriceRatio { get; set; }

          public Guid? CreatedBy { get; set; }
          public DateTime? CreatedDate { get; set; }
          public Guid? LastModifiedBy { get; set; }
          public DateTime? LastModifiedDate { get; set; }
          public bool? IsActive { get; set; }
     }
}
