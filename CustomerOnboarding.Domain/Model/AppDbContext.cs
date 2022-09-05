using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomerOnboarding.Domain.Model
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<LendingHistory> LendingHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
               .Property("Id").UseIdentityColumn();

            modelBuilder.Entity<Customer>()
                .HasOne(b => b.User)
                .WithOne();

            //modelBuilder.Entity<Books>()
            //    .HasOne(x => x.Customer)
            //    .WithOne(x => x.Books)
            //    .HasForeignKey(x => x);
            //modelBuilder.Entity<Customer>()
            //    .HasOne(b => b.Book)
            //    .WithOne()
            //    .HasForeignKey<Books>(x => x.BookId);

            modelBuilder.Entity<Books>()
                .HasOne(x => x.Customer)
                .WithOne(b => b.Book)
                .HasForeignKey<Customer>(x => x.BookId);

            //modelBuilder.Entity<LendingHistory>()
            //    .HasOne(b => b.Customer)
            //    .WithOne(x => x.)
            //    .HasForeignKey<LendingHistory>(x => x.LendingHistoryId);

            //modelBuilder.Entity<LendingHistory>()
            //  .HasOne(b => b.Book)
            //  .WithOne()
            //  .HasForeignKey<LendingHistory>(x => x.LendingHistoryId);


            //.WithOne(x => x.Customer)
            //.HasForeignKey(x => x.CustomerId);

            //modelBuilder.Entity<Books>()
            //    .HasOne(x => x.Customer)
            //    .WithOne(x => x.Books);
            //.HasForeignKey(x => x.)




            modelBuilder.Entity<ApplicationRole>()
              .Property("Id").UseIdentityColumn();
        }
    }
}
