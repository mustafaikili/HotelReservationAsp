using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Entities
{
     public class Rooms : IEntity
    {
        public int RoomNumber { get; set; }
        public Guid RoomTypeID { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        //Navigation Properties
        public virtual RoomTypes RoomType { get; set; }
        public virtual ICollection<RoomImages> RoomImage { get; set; }
        public virtual ICollection<ResCusRooms> ResCusRoom { get; set; }
    }
}
