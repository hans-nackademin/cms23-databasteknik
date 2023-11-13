﻿namespace _01_Database_with_SqlClient.Models;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } 
    public decimal Price { get; set; }
}
