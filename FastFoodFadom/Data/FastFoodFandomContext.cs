using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class FastFoodFandomContext : DbContext
    {
        public FastFoodFandomContext()
        {
        }

        public FastFoodFandomContext(DbContextOptions<FastFoodFandomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Drink> Drink { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderFromMenu> OrderFromMenu { get; set; }
        public virtual DbSet<Snack> Snack { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=FastFoodFandom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Login);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.DrinkId).ValueGeneratedNever();

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderKey);

                entity.Property(e => e.OrderKey).ValueGeneratedNever();

                entity.Property(e => e.Coast).HasMaxLength(50);

                entity.Property(e => e.Date).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderFromMenu>(entity =>
            {
                entity.HasKey(e => e.OrderKey);

                entity.Property(e => e.OrderKey).ValueGeneratedNever();

                entity.Property(e => e.NameOf).HasMaxLength(50);

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.OrderFromMenu)
                    .HasForeignKey(d => d.Drinkid)
                    .HasConstraintName("FK_OrderFromMenu_Drink");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderFromMenu)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_OrderFromMenu_Food");

                entity.HasOne(d => d.Snack)
                    .WithMany(p => p.OrderFromMenu)
                    .HasForeignKey(d => d.SnackId)
                    .HasConstraintName("FK_OrderFromMenu_Snack");
            });

            modelBuilder.Entity<Snack>(entity =>
            {
                entity.Property(e => e.SnackId).ValueGeneratedNever();

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(e => e.OrderKey);

                entity.Property(e => e.OrderKey).ValueGeneratedNever();

                entity.Property(e => e.Coast)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HowMach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
