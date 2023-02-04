﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSolution.Domain;

namespace TicketingSolution.Persistence
{
    public class TicketingSolutionDbContext : DbContext
    {
        public TicketingSolutionDbContext(DbContextOptions<TicketingSolutionDbContext> options)
            : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Name = "To Fars" },
                new Ticket { Id = 1, Name = "To Mashhad" },
                new Ticket { Id = 1, Name = "To Yazd" }
            );
        }
    }
}
