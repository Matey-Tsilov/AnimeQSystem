﻿using AnimeQSystem.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace AnimeQSystem.Data.Models
{
    public class User
    {
        public Guid Id = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public int Points { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public string Country { get; set; } = null!;

        // Navigation properties
        public string IdentityUserId { get; set; } = null!;
        public virtual IdentityUser IdentityUser { get; set; } = null!;
    }
}
