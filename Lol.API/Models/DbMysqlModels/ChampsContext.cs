using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Lol.API.Models.DbMysqlModels;

public partial class ChampsContext : DbContext
{
    public ChampsContext()
    {
    }

    public ChampsContext(DbContextOptions<ChampsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=champs;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_hungarian_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orders")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.BlueEssence)
                .HasColumnType("int(5)")
                .HasColumnName("blue_essence");
            entity.Property(e => e.DamageType)
                .HasMaxLength(5)
                .HasColumnName("damage_type");
            entity.Property(e => e.Description)
                .HasMaxLength(6)
                .HasColumnName("description");
            entity.Property(e => e.Difficulty)
                .HasColumnType("int(1)")
                .HasColumnName("difficulty");
            entity.Property(e => e.Id)
                .HasColumnType("int(1)")
                .HasColumnName("id");
            entity.Property(e => e.Images)
                .HasMaxLength(6)
                .HasColumnName("images");
            entity.Property(e => e.Lane)
                .HasMaxLength(3)
                .HasColumnName("lane");
            entity.Property(e => e.Name)
                .HasMaxLength(6)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(8)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
