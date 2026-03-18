using HRManagment.Domain.Common;
using HRManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public UserRole Role { get; set; }

        public User() { }

        public User(string name, string lastName, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = true;
            Role = UserRole.HRManager;
        }
    }
}
