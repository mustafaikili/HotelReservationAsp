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
     public class CustomersMap : EntityTypeConfiguration<Customers>
     {
          public CustomersMap()
          {
               //PrimaryKey
               HasKey(x => x.CustomerID);

               //Property
               Property(x => x.CivilizationNumber).HasColumnType("nvarchar").HasMaxLength(11).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("CivilizationNumber_Unique") { IsUnique = true })).IsRequired();
               Property(x => x.FirstName).HasMaxLength(50).IsRequired();
               Property(x => x.LastName).HasMaxLength(50).IsRequired();
               Property(x => x.Email).HasMaxLength(50).IsOptional();
               Property(x => x.Telephone).HasMaxLength(50).IsOptional();

               //
               Property(x => x.CreatedBy).IsOptional();
               Property(x => x.CreatedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.LastModifiedBy).IsOptional();
               Property(x => x.LastModifiedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.IsActive).IsOptional();
          }
     }
}
