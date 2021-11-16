using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class BudgetTrackerDbContext :DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditures);
            modelBuilder.Entity<Income>(ConfigureIncomes);
        }

        private void ConfigureIncomes(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.HasOne(e => e.User).WithMany(u => u.Incomes).HasForeignKey(e => e.UserId);
        }

        private void ConfigureExpenditures(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.HasOne(e => e.User).WithMany(u => u.Expenditures).HasForeignKey(e => e.UserId);
        }

        //private void ConfigureUser(EntityTypeBuilder<User> builder)
        //{
        //    //throw new NotImplementedException();
        //    builder.ToTable("Users");
        //    builder.Property(u => u.Email).HasMaxLength(50);
        //    builder.Property(u => u.Password).HasMaxLength(10);
        //    builder.Property(u => u.Fullname).HasMaxLength(50);
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Income> Incomes { get; set; }

    }
}
