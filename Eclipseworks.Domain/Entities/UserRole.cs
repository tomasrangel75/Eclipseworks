﻿namespace Eclipseworks.Domain.Entities
{
    public sealed class UserRole
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int RoleId { get; set; }
                
        public Role? Role { get; set; }
    }
}
