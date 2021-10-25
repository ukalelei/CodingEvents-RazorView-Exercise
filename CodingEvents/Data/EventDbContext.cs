using System;
using CodingEvents.Models;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Data
{
    public class EventDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Event> Events { get; set; } //primary key
        public DbSet<EventCategory> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EventTag> EventTags { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTag>()
                  .HasKey(et => new { et.EventId, et.TagId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
