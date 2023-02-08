using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Province { get; set; }
        public string UserId { get; set; } = null!;

        public virtual AspNetUser User { get; set; } = null!;
    }
}
