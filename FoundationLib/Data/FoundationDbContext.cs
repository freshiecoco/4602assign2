using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FoundationLib.Models;

namespace FoundationLib.Data;

public class FoundationDbContext : IdentityDbContext
{
    public DbSet<Donor> Donors => Set<Donor>();
    public DbSet<Donation> Donations => Set<Donation>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
    
    public FoundationDbContext(DbContextOptions<FoundationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Donor>().HasData(SampleData.GetDonors());
        modelBuilder.Entity<PaymentMethod>().HasData(SampleData.GetPaymentMethods());
        modelBuilder.Entity<TransactionType>().HasData(SampleData.GetTransactionTypes());
        modelBuilder.Entity<Donation>().HasData(SampleData.GetDonations());
        
    }
}

