using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Mapping.EFMapping
{
     public class ReservationsMap : EntityTypeConfiguration<Reservations>
     {
          public ReservationsMap()
          {
               //PrimaryKey
               HasKey(x => x.ReservationID);

               //Property
               Property(x => x.ReservationDate).IsRequired();
               Property(x => x.StartDate).HasColumnType("date").IsRequired();
               Property(x => x.EndDate).HasColumnType("date").IsRequired();
               Property(x => x.PersonCount).IsRequired();

               //
               Property(x => x.CreatedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.LastModifiedBy).IsOptional();
               Property(x => x.LastModifiedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.IsActive).IsOptional();

               //ForeignKey
               HasRequired(x => x.ReservationType).WithMany(x => x.Reservation).HasForeignKey(x => x.ReservationTypeID).WillCascadeOnDelete(true);
               HasRequired(x => x.User).WithMany(x => x.Reservation).HasForeignKey(x => x.UserID).WillCascadeOnDelete(true);
          }
     }
}
