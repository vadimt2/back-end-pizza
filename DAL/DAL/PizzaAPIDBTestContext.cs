using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DAL
{
    public partial class PizzaAPIDBTestContext : DbContext
    {
        public PizzaAPIDBTestContext()
        {
        }

        public PizzaAPIDBTestContext(DbContextOptions<PizzaAPIDBTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BellingAndShippInfo> BellingAndShippInfo { get; set; }
        public virtual DbSet<CategoryItems> CategoryItems { get; set; }
        public virtual DbSet<Catrgories> Catrgories { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=pizzademo10.cokncynj01yy.us-east-2.rds.amazonaws.com,1433;Initial Catalog=PizzaAPIDBTest;User ID=pizzademo10;Password=pizzademo10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BellingAndShippInfo>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BellingAndShippInfo)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<CategoryItems>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.ItemId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryItems)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CategoryItems)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasIndex(e => e.ItemId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasIndex(e => e.ParentItemId);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.ParentItem)
                    .WithMany(p => p.InverseParentItem)
                    .HasForeignKey(d => d.ParentItemId);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasIndex(e => e.ItemId);

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.SellPrice).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ItemId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.ShippingId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Email).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
