
using lab1_gazizov.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace lab1_gazizov.Data
{
    public class BarbershopContext : DbContext
    {
        public BarbershopContext(DbContextOptions<BarbershopContext> options)
            : base(options)
        {
        }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Добавление начальных данных для Barbers
            modelBuilder.Entity<Barber>().HasData(
                new Barber { Id = 1, Name = "Иван Иванов", ExperienceLevel = 5 },
                new Barber { Id = 2, Name = "Петр Петров", ExperienceLevel = 3 }
            );

            // Добавление начальных данных для Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Алексей Смирнов", PreferredStyle = "Классический" },
                new Customer { Id = 2, Name = "Мария Сидорова", PreferredStyle = "Модерн" }
            );

            // Добавление начальных данных для Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, BarberId = 1, CustomerId = 1, AppointmentTime = DateTime.Now.AddHours(1) },
                new Appointment { Id = 2, BarberId = 2, CustomerId = 2, AppointmentTime = DateTime.Now.AddHours(3) }
            );
        }
    }
}
