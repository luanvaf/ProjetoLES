using System;

namespace Domain.Entities
{
    public class Address : Entity<Guid>
    {
        public string District { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
