﻿using Data.Entities;

namespace Business.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public int CustomerId { get; set; }
    public int RoleId { get; set; }
}


             