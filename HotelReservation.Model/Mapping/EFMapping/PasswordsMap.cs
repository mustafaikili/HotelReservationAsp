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
     public class PasswordsMap : EntityTypeConfiguration<Passwords>
     {
          public PasswordsMap()
          {
               //PrimaryKey
               HasKey(x => x.PasswordID);

               //Property
               Property(x => x.Password).HasMaxLength(50).IsRequired();

               //
               Property(x => x.CreatedBy).IsOptional();
               Property(x => x.CreatedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.LastModifiedBy).IsOptional();
               Property(x => x.LastModifiedDate).HasColumnType("datetime2").HasPrecision(0).IsOptional();
               Property(x => x.IsActive).IsOptional();

               //ForeignKey
               HasRequired(x => x.User).WithMany(x => x.Password).HasForeignKey(x => x.UserID).WillCascadeOnDelete(true);
          }
     }
}
