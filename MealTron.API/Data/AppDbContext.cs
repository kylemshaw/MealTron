using System;
using MealTron.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealTron.API.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; } 
    
}
