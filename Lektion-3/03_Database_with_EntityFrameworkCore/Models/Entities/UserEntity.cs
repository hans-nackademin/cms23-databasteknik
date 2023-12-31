﻿namespace _03_Database_with_EntityFrameworkCore.Models.Entities;

internal class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}
