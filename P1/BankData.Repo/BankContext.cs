using System;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankData.Repo;

public class BankContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }

    public BankContext(DbContextOptions<BankContext> options) : base(options){}
    
}
