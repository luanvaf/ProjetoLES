using System;

namespace Domain.Entities
{
    /// <summary>
    /// base entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
