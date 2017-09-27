using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Mapping.EFMapping
{
     public class RoomsMap : EntityTypeConfiguration<Rooms>
     {
          public RoomsMap()
          {
               //PrimaryKey
               HasKey(x => x.RoomNumber);

               //Property
               Property(x => x.RoomNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

               //
               Property(x => x.CreatedBy).IsOptional();
               Property(x => x.CreatedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.LastModifiedBy).IsOptional();
               Property(x => x.LastModifiedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.IsActive).IsOptional();

               //ForeignKey
               HasRequired(x => x.RoomType).WithMany(x => x.Room).HasForeignKey(x => x.RoomTypeID).WillCascadeOnDelete(true);
          }
     }
}
