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
     public class PriceRatiosMap : EntityTypeConfiguration<PriceRatios>
     {
          public PriceRatiosMap()
          {
               //PrimaryKey
               HasKey(x => x.PriceRatioID);

               //Property
               Property(x => x.PriceRatioName).HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("PriceRatioName_Unique") { IsUnique = true })).IsRequired();
               Property(x => x.PriceRatio).IsRequired();

               //
               Property(x => x.CreatedBy).IsOptional();
               Property(x => x.CreatedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.LastModifiedBy).IsOptional();
               Property(x => x.LastModifiedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.IsActive).IsOptional();
          }
     }
}
