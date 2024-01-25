using Claims.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Data
{
    public class ClaimsDbContext : DbContext
    {
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ClaimsDbContext(DbContextOptions<ClaimsDbContext> options)
        : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Company)
                .WithMany(company => company.Claims)
                .HasForeignKey(claim => claim.CompanyId);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.ClaimType)
                .WithMany()
                .HasForeignKey(c => c.ClaimTypeId);           // Add any additional configurations or relationships here
        }
    }
}
