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
        public virtual DbSet<OrderFromMenu> OrderFromMenu { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Snack> Snack { get; set; }

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

            modelBuilder.Entity<OrderFromMenu>(entity =>
            {
                entity.HasKey(e => e.CodOfOrder);

                entity.Property(e => e.CodOfOrder)
                    .HasColumnName("Cod_of_order")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodOfDrink).HasColumnName("Cod_of_drink");

                entity.Property(e => e.CodOfFood).HasColumnName("Cod_of_food");

                entity.Property(e => e.CodOfSnack).HasColumnName("Cod_of_snack");

                entity.HasOne(d => d.CodOfDrinkNavigation)
                    .WithMany(p => p.OrderFromMenu)
                    .HasForeignKey(d => d.CodOfDrink)
                    .HasConstraintName("FK_OrderFromMenu_Drink");

                entity.HasOne(d => d.CodOfFoodNavigation)
                    .WithMany(p => p.OrderFromMenu)
                    .HasForeignKey(d => d.CodOfFood)
                    .HasConstraintName("FK_OrderFromMenu_Food");

                entity.HasOne(d => d.CodOfSnackNavigation)
                    .WithMany(p => p.OrderFromMenu)
                    .HasForeignKey(d => d.CodOfSnack)
                    .HasConstraintName("FK_OrderFromMenu_Snack");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.CodOfOrder);

                entity.Property(e => e.CodOfOrder)
                    .HasColumnName("Cod_of_order")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.HasOne(d => d.CodOfOrderNavigation)
                    .WithOne(p => p.Orders)
                    .HasForeignKey<Orders>(d => d.CodOfOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderFromMenu");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
