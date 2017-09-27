using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Model.Entities;
using HotelReservation.Model.Mapping.EFMapping;

namespace HotelReservation.DataAccess.Concreate.EntityFramework
{
     public class HotelReservationDBContext : DbContext
     {
          public HotelReservationDBContext()
               : base("Server=.;Database=IndiaHotelReservation;Integrated Security=True")
          {
               Database.SetInitializer<HotelReservationDBContext>(new DropCreateDatabaseIfModelChanges<HotelReservationDBContext>());
          }

          public DbSet<Users> User { get; set; }
          public DbSet<RoomTypes> RoomType { get; set; }
          public DbSet<Rooms> Room { get; set; }
          public DbSet<RoomImages> RoomImage { get; set; }
          public DbSet<ReservationTypes> ReservationType { get; set; }
          public DbSet<Reservations> Reservation { get; set; }
          public DbSet<ResCusRooms> ResCusRoom { get; set; }
          public DbSet<PriceRatios> PriceRatio { get; set; }
          public DbSet<PaymentTypes> PaymentType { get; set; }
          public DbSet<Payments> Payment { get; set; }
          public DbSet<Passwords> Password { get; set; }
          public DbSet<Customers> Customer { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Configurations.Add(new UsersMap());
               modelBuilder.Configurations.Add(new RoomTypesMap());
               modelBuilder.Configurations.Add(new RoomsMap());
               modelBuilder.Configurations.Add(new RoomImagesMap());
               modelBuilder.Configurations.Add(new ReservationsTypesMap());
               modelBuilder.Configurations.Add(new ReservationsMap());
               modelBuilder.Configurations.Add(new ResCusRoomsMap());
               modelBuilder.Configurations.Add(new PriceRatiosMap());
               modelBuilder.Configurations.Add(new PaymentTypesMap());
               modelBuilder.Configurations.Add(new PaymentsMap());
               modelBuilder.Configurations.Add(new PasswordsMap());
               modelBuilder.Configurations.Add(new CustomersMap());
          }
     }
}
