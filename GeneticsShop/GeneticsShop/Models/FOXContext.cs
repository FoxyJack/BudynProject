using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GeneticsShop.Models
{
    public partial class FOXContext : DbContext
    {
        public FOXContext()
        {
        }

        public FOXContext(DbContextOptions<FOXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Foxes> Foxes { get; set; }
        public virtual DbSet<Katanas> Katanas { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foxes>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.IdProduct)
                    .HasColumnName("id_product")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tails)
                    .HasColumnName("tails")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithOne(p => p.Foxes)
                    .HasForeignKey<Foxes>(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Foxes_Product");
            });

            modelBuilder.Entity<Katanas>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.IdProduct)
                    .HasColumnName("id_product")
                    .ValueGeneratedNever();

                entity.Property(e => e.Sharpness).HasColumnName("sharpness");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithOne(p => p.Katanas)
                    .HasForeignKey<Katanas>(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Katanas_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(15, 2)")
                    .HasDefaultValueSql("((1.0))");
            });
        }
    }
}
