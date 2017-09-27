using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Mapping.EFMapping
{
     public class ResCusRoomsMap : EntityTypeConfiguration<ResCusRooms>
     {
          public ResCusRoomsMap()
          {
               //PrimaryKey
               HasKey(x => new { x.ReservationID, x.CustomerID, x.RoomNumber });

               //ForeignKey
               HasRequired(x => x.Reservation).WithMany(x => x.ResCusRoom).HasForeignKey(x => x.ReservationID).WillCascadeOnDelete(true);
               HasRequired(x => x.Customer).WithMany(x => x.ResCumRoom).HasForeignKey(x => x.CustomerID).WillCascadeOnDelete(true);
               HasRequired(x => x.Room).WithMany(x => x.ResCusRoom).HasForeignKey(x => x.RoomNumber).WillCascadeOnDelete(true);
          }
     }
}
