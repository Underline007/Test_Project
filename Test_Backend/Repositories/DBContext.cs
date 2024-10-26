using Microsoft.EntityFrameworkCore;
using Test_Backend.Models.Entities;

namespace Test_Backend.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Order entity
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.OrderCode);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TotalAmount)
                    .IsRequired();

                entity.Property(e => e.TotalTax)
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired();
            });

            // Configure OrderItem entity
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.OrderCode)
                    .IsRequired();

                entity.Property(e => e.ProductCode)
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.SellingPrice)
                    .IsRequired();

                entity.Property(e => e.TaxRate)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.TaxAmount)
                    .IsRequired();

                entity.Property(e => e.LineAmount)
                    .IsRequired();

                // Configure relationships
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(e => e.OrderCode)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(e => e.ProductCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.ProductCode);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImportPrice)
                    .IsRequired();

                entity.Property(e => e.SellingPrice)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.TaxRate)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();
            });
        }
    }
}
