﻿namespace lab1_gazizov.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; } // Длительность услуги в минутах
    }
}
