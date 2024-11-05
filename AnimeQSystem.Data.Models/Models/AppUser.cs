﻿using AnimeQSystem.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace AnimeQSystem.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid();
        }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public int Points { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public string Country { get; set; } = null!;
    }
}
