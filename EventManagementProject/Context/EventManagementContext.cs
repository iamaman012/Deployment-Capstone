
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Numerics;

namespace EventManagementProject.Context
{
    public class EventManagementContext : DbContext
    {
        public EventManagementContext(DbContextOptions<EventManagementContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PrivateQuotationRequest> PrivateQuotationRequests { get; set; }
        public DbSet<PrivateQuotationResponse> PrivateQuotationResponses { get; set; }
        public DbSet<ScheduledPrivateEvent> ScheduledPrivateEvents { get; set; }
        public DbSet<PublicQuotationRequest> PublicQuotationRequests { get; set; }
        public DbSet<PublicQuotationResponse> PublicQuotationResponses { get; set; }
        public DbSet<ScheduledPublicEvent> ScheduledPublicEvents { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User to UserCredential (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserCredential)
                .WithOne(uc => uc.User)
                .HasForeignKey<UserCredential>(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User to PrivateQuotationRequests (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.PrivateQuotationRequests)
                .WithOne(pqr => pqr.User)
                .HasForeignKey(pqr => pqr.UserId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // Event to PrivateQuotationRequests (One-to-Many)
            modelBuilder.Entity<Event>()
                .HasMany(e => e.PrivateQuotationRequests)
                .WithOne(pqr => pqr.Event)
                .HasForeignKey(pqr => pqr.EventId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // PrivateQuotationRequest to PrivateQuotationResponse (One-to-One)
            modelBuilder.Entity<PrivateQuotationRequest>()
                .HasOne(pqr => pqr.PrivateQuotationResponse)
                .WithOne(pqr => pqr.PrivateQuotationRequest)
                .HasForeignKey<PrivateQuotationResponse>(pqr => pqr.PrivateQuotationRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // PrivateQuotationRequest to ScheduledPrivateEvent (One-to-One)
            modelBuilder.Entity<PrivateQuotationRequest>()
                .HasOne(pqr => pqr.ScheduledPrivateEvent)
                .WithOne(spe => spe.PrivateQuotationRequest)
                .HasForeignKey<ScheduledPrivateEvent>(spe => spe.PrivateQuotationRequestId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // User to ScheduledPrivateEvents (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ScheduledPrivateEvents)
                .WithOne(spe => spe.User)
                .HasForeignKey(spe => spe.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User to PublicQuotationRequests (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.PublicQuotationRequests)
                .WithOne(pqr => pqr.User)
                .HasForeignKey(pqr => pqr.UserId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // Event to PublicQuotationRequests (One-to-Many)
            modelBuilder.Entity<Event>()
                .HasMany(e => e.PublicQuotationRequests)
                .WithOne(pqr => pqr.Event)
                .HasForeignKey(pqr => pqr.EventId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // PublicQuotationRequest to PublicQuotationResponse (One-to-One)
            modelBuilder.Entity<PublicQuotationRequest>()
                .HasOne(pqr => pqr.PublicQuotationResponse)
                .WithOne(pqr => pqr.PublicQuotationRequest)
                .HasForeignKey<PublicQuotationResponse>(pqr => pqr.PublicQuotationRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // PublicQuotationRequest to ScheduledPublicEvent (One-to-One)
            modelBuilder.Entity<PublicQuotationRequest>()
                .HasOne(pqr => pqr.ScheduledPublicEvent)
                .WithOne(spe => spe.PublicQuotationRequest)
                .HasForeignKey<ScheduledPublicEvent>(spe => spe.PublicQuotationRequestId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // User to ScheduledPublicEvents (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ScheduledPublicEvents)
                .WithOne(spe => spe.User)
                .HasForeignKey(spe => spe.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ScheduledPublicEvent to Tickets (One-to-Many)
            modelBuilder.Entity<ScheduledPublicEvent>()
                .HasMany(spe => spe.Tickets)
                .WithOne(t => t.ScheduledPublicEvent)
                .HasForeignKey(t => t.ScheduledPublicEventId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // User to Tickets (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Additional configurations can go here...
        }


    }
}
