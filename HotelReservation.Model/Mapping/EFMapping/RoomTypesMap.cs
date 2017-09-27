using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Model.Mapping.EFMapping
{
     public class RoomTypesMap : EntityTypeConfiguration<RoomTypes>
     {
          public RoomTypesMap()
          {
               //PrimaryKey
               HasKey(x => x.RoomTypeID);

               //Property
               Property(x => x.RoomTypeName).HasColumnType("nvarchar").HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("RoomTypeName_Unique") { IsUnique = true })).IsRequired();
               Property(x => x.RoomTypePrice).HasColumnType("money").IsRequired();
               Property(x => x.Description).HasMaxLength(500).IsOptional();

               //
               Property(x => x.CreatedBy).IsOptional();
               Property(x => x.CreatedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.LastModifiedBy).IsOptional();
               Property(x => x.LastModifiedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.IsActive).IsOptional();
          }
     }
}
