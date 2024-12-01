
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
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Добавление начальных данных для Barbers
            modelBuilder.Entity<Barber>().HasData(
                new Barber { Id = 1, Name = "Иван Иванов", ExperienceLevel = 5 },
                new Barber { Id = 2, Name = "Петр Петров", ExperienceLevel = 3 },
                new Barber { Id = 3, Name = "Андрей Морозов", ExperienceLevel = 5 },
                new Barber { Id = 4, Name = "Максим Клюев", ExperienceLevel = 3 },
                new Barber { Id = 5, Name = "Виталий Костенко", ExperienceLevel = 5 },
                new Barber { Id = 6, Name = "Семен Даниилов", ExperienceLevel = 3 },
                new Barber { Id = 7, Name = "Артур Манасян", ExperienceLevel = 5 },
                new Barber { Id = 8, Name = "Амир Мурадов", ExperienceLevel = 3 },
                new Barber { Id = 9, Name = "Азамат Халитович", ExperienceLevel = 5 },
                new Barber { Id = 10, Name = "Мимкаел Довлатбекян", ExperienceLevel = 3 },
                new Barber { Id = 11, Name = "Арман Маникян", ExperienceLevel = 5 },
                new Barber { Id = 12, Name = "Андрей Балаян", ExperienceLevel = 3 }

            );

            // Добавление начальных данных для Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Алексей Смирнов", PreferredStyle = "Классический" },
                new Customer { Id = 2, Name = "Дмитрий Винарчук", PreferredStyle = "Под ноль" },
                new Customer { Id = 3, Name = "Валера Деонтьев", PreferredStyle = "Тройка" },
                new Customer { Id = 4, Name = "Филипп Киркоров", PreferredStyle = "Двойка" },
                new Customer { Id = 5, Name = "Вазген Каспарянц", PreferredStyle = "Под ноль" },
                new Customer { Id = 6, Name = "Ашот Саркисян", PreferredStyle = "Классический" },
                new Customer { Id = 7, Name = "Рустам Хайруллин", PreferredStyle = "Классический" },
                new Customer { Id = 8, Name = "Рустам Шайхутдинов", PreferredStyle = "Модерн" },
                new Customer { Id = 9, Name = "Булат Сидиков", PreferredStyle = "Тройка" },
                new Customer { Id = 10, Name = "Иван Туманов", PreferredStyle = "Модерн" },
                new Customer { Id = 11, Name = "Салават Юлаев", PreferredStyle = "Тройка" },
                new Customer { Id = 12, Name = "Айбек Сулейманов", PreferredStyle = "Модерн" },
                new Customer { Id = 13, Name = "Булат Шатрашанов", PreferredStyle = "Двойка" },
                new Customer { Id = 14, Name = "Ильяс Фархутдинов", PreferredStyle = "Двойка" }

            );

            // Добавление начальных данных для Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, BarberId = 1, CustomerId = 1, ServiceId = 1, AppointmentTime = DateTime.Now.AddHours(1) },
                new Appointment { Id = 2, BarberId = 2, CustomerId = 2, ServiceId = 2, AppointmentTime = DateTime.Now.AddHours(1).AddMinutes(30) },
                new Appointment { Id = 3, BarberId = 3, CustomerId = 3, ServiceId = 3, AppointmentTime = DateTime.Now.AddHours(2) },
                new Appointment { Id = 4, BarberId = 4, CustomerId = 4, ServiceId = 4, AppointmentTime = DateTime.Now.AddHours(3) },
                new Appointment { Id = 5, BarberId = 5, CustomerId = 5, ServiceId = 5, AppointmentTime = DateTime.Now.AddHours(3).AddMinutes(30) },
                new Appointment { Id = 6, BarberId = 6, CustomerId = 6, ServiceId = 6, AppointmentTime = DateTime.Now.AddHours(4) },
                new Appointment { Id = 7, BarberId = 7, CustomerId = 7, ServiceId = 7, AppointmentTime = DateTime.Now.AddHours(5) },
                new Appointment { Id = 8, BarberId = 8, CustomerId = 8, ServiceId = 8, AppointmentTime = DateTime.Now.AddHours(6) },
                new Appointment { Id = 9, BarberId = 9, CustomerId = 9, ServiceId = 9, AppointmentTime = DateTime.Now.AddHours(6).AddMinutes(30) },
                new Appointment { Id = 10, BarberId = 10, CustomerId = 10, ServiceId = 10, AppointmentTime = DateTime.Now.AddHours(7) },
                new Appointment { Id = 11, BarberId = 11, CustomerId = 11, ServiceId = 11, AppointmentTime = DateTime.Now.AddHours(8) },
                new Appointment { Id = 12, BarberId = 12, CustomerId = 12, ServiceId = 12, AppointmentTime = DateTime.Now.AddHours(9) },
                new Appointment { Id = 13, BarberId = 1, CustomerId = 13, ServiceId = 13, AppointmentTime = DateTime.Now.AddHours(9).AddMinutes(30) },
                new Appointment { Id = 14, BarberId = 2, CustomerId = 14, ServiceId = 14, AppointmentTime = DateTime.Now.AddHours(10) },
                new Appointment { Id = 15, BarberId = 3, CustomerId = 1, ServiceId = 15, AppointmentTime = DateTime.Now.AddHours(11) },
                new Appointment { Id = 16, BarberId = 4, CustomerId = 2, ServiceId = 16, AppointmentTime = DateTime.Now.AddHours(12) },
                new Appointment { Id = 17, BarberId = 5, CustomerId = 3, ServiceId = 17, AppointmentTime = DateTime.Now.AddHours(13) },
                new Appointment { Id = 18, BarberId = 6, CustomerId = 4, ServiceId = 18, AppointmentTime = DateTime.Now.AddHours(13).AddMinutes(30) },
                new Appointment { Id = 19, BarberId = 7, CustomerId = 5, ServiceId = 19, AppointmentTime = DateTime.Now.AddHours(14) },
                new Appointment { Id = 20, BarberId = 8, CustomerId = 6, ServiceId = 1, AppointmentTime = DateTime.Now.AddHours(15) },
                new Appointment { Id = 21, BarberId = 9, CustomerId = 7, ServiceId = 2, AppointmentTime = DateTime.Now.AddHours(16) },
                new Appointment { Id = 22, BarberId = 10, CustomerId = 8, ServiceId = 3, AppointmentTime = DateTime.Now.AddHours(16).AddMinutes(30) },
                new Appointment { Id = 23, BarberId = 11, CustomerId = 9, ServiceId = 4, AppointmentTime = DateTime.Now.AddHours(17) },
                new Appointment { Id = 24, BarberId = 12, CustomerId = 10, ServiceId = 5, AppointmentTime = DateTime.Now.AddHours(18) }


            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Стрижка", Price = 500, Duration = 30 },
            new Service { Id = 2, Name = "Бритье", Price = 300, Duration = 20 },
            new Service { Id = 3, Name = "Укладка", Price = 400, Duration = 40 },
            new Service { Id = 4, Name = "Окрашивание", Price = 1200, Duration = 90 },
            new Service { Id = 5, Name = "Массаж головы", Price = 700, Duration = 25 },
            new Service { Id = 6, Name = "Мытье головы", Price = 200, Duration = 15 },
            new Service { Id = 7, Name = "Комплекс: стрижка и укладка", Price = 800, Duration = 60 },
            new Service { Id = 8, Name = "Коррекция бороды", Price = 350, Duration = 20 },
            new Service { Id = 9, Name = "Детская стрижка", Price = 400, Duration = 25 },
            new Service { Id = 10, Name = "Камуфлирование седины", Price = 1000, Duration = 45 },
            new Service { Id = 11, Name = "Королевское бритье", Price = 600, Duration = 40 },
            new Service { Id = 12, Name = "Оформление усов", Price = 150, Duration = 10 },
            new Service { Id = 13, Name = "Уход за кожей лица", Price = 500, Duration = 30 },
            new Service { Id = 14, Name = "Тонирование волос", Price = 800, Duration = 60 },
            new Service { Id = 15, Name = "Укладка усов", Price = 200, Duration = 15 },
            new Service { Id = 16, Name = "Комплекс: бритье и массаж головы", Price = 900, Duration = 50 },
            new Service { Id = 17, Name = "Лечебное мытье головы", Price = 300, Duration = 20 },
            new Service { Id = 18, Name = "Стрижка машинкой", Price = 250, Duration = 15 },
            new Service { Id = 19, Name = "Тримминг бороды", Price = 300, Duration = 25 },
            new Service { Id = 20, Name = "Элитное бритье с маслом", Price = 700, Duration = 45 }

            );
        }
    }
}
