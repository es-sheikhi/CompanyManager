using CompanyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Infrastructure.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestCompanyDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>(options =>
            {
                options.HasData(new Company[]
                {
                    new Company
                    {
                        Id=Guid.NewGuid(),
                        Address="Address1",
                        Email="mycompany@my.com",
                        Name="my",
                        Phone="03137883123"
                    },
                    new Company
                    {
                        Id=Guid.NewGuid(),
                        Address="Address2",
                        Email="yourcompany@your.com",
                        Name="your",
                        Phone="01199883123"
                    },
                    new Company
                    {
                        Id=Guid.NewGuid(),
                        Address="Address3",
                        Email="hercompany@her.com",
                        Name="her",
                        Phone="02122283123"
                    }
                });
            });
        }
    }
}
