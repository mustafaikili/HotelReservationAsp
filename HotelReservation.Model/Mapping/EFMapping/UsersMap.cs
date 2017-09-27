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
     public class UsersMap : EntityTypeConfiguration<Users>
     {
          public UsersMap()
          {
               //PrimaryKey
               HasKey(x => x.UserID);

               //Property
               Property(x => x.CivilizationNumber).HasColumnType("nvarchar").HasMaxLength(11).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("CivilizationNumber_Unique") { IsUnique = true })).IsRequired();
               Property(x => x.UserName).HasColumnType("nvarchar").HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("UserName_Unique") { IsUnique = true })).IsRequired();
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
