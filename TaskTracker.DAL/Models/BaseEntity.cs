﻿namespace TaskTracker.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime FineshedAt { get; set; }
    }
}
