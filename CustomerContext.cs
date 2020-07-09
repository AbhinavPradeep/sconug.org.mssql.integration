using System;
using Microsoft.EntityFrameworkCore;

namespace sconug.org.mssql.integration
{
    public class CustomerContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<CustomerEventTag> Customer_EventTags { get; set; }
        public DbSet<EventEventTag> Event_EventTags { get; set; }
        public DbSet<CustomerEvent> Customer_Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=sconugDB;user=sa;password=D1@m0nds");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerEventTag>(entity =>
                {
                    entity.HasKey(ct => new{ct.EventTagID,ct.CustomerID});
                }
            );
            modelBuilder.Entity<EventEventTag>(entity => 
                {
                    entity.HasKey(ee => new{ee.EventID,ee.EventTagID});
                }
            );
            modelBuilder.Entity<CustomerEvent>(entity =>
                {
                    entity.HasKey(ce => new{ce.EventID,ce.CustomerID});
                }
            );
        }

    }
}
