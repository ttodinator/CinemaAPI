using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Entities
{
    public class DataContext:IdentityDbContext<AppUser, AppRole, int,
                 IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
         IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Screening> Screening { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<SeatReservation> SeatReservation { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Role>().HasKey(r => new { r.Id, r.MovieId });

            builder.Entity<Seat>().HasKey(s => new { s.Id, s.HallId });

            builder.Entity<SeatReservation>().HasKey(sr => new { sr.SeatId, sr.Reservationid, sr.HallId });

            builder.Entity<SeatReservation>()
                .HasOne(sr => sr.Reservation)
                .WithMany(r=>r.SeatReservations)
                .HasForeignKey(sr=> sr.Reservationid)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SeatReservation>()
                .HasOne(sr => sr.Seat)
                .WithMany(r => r.SeatReservations)
                .HasForeignKey(sr=>new {sr.SeatId, sr.HallId})
                .OnDelete(DeleteBehavior.NoAction);

        }

        //private void SeedUsersAndRoles()
        //{
        //    var roles = new List<AppRole>
        //    {
        //        new AppRole{Name="Member"},
        //        new AppRole{Name="Admin"},
        //        new AppRole{Name="Moderator"}
        //    };

        //    foreach (var role in roles)
        //    {
        //        await roleManager.CreateAsync(role);
        //    }

        //    var admin = new AppUser
        //    {
        //        UserName = "admin"
        //    };

        //    await userManager.CreateAsync(admin, "Pa$$w0rd");
        //    await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
        //}
    }
}
