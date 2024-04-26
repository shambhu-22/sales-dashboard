using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DashBoardAPI.Models;

public partial class ModelDataContext : DbContext
{
    public ModelDataContext()
    {
    }

    public ModelDataContext(DbContextOptions<ModelDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SalesDatum> SalesData { get; set; }
    public DbSet<ModelData> TotalSumResults { get; set; }
    public DbSet<SalesRankedData> RankedSalesResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalesDat__3214EC27449F4806");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Date11062023).HasColumnName("Date_11_06_2023");
            entity.Property(e => e.Date12062023).HasColumnName("Date_12_06_2023");
            entity.Property(e => e.Date13062023).HasColumnName("Date_13_06_2023");
            entity.Property(e => e.Date14062023).HasColumnName("Date_14_06_2023");
            entity.Property(e => e.Date15062023).HasColumnName("Date_15_06_2023");
            entity.Property(e => e.Date16062023).HasColumnName("Date_16_06_2023");
            entity.Property(e => e.Date17062023).HasColumnName("Date_17_06_2023");
            entity.Property(e => e.Product)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ModelData>().HasNoKey().ToView(null);
        modelBuilder.Entity<SalesRankedData>().HasNoKey().ToView(null);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
