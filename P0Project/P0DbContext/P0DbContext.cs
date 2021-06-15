using Microsoft.EntityFrameworkCore;
using ML = ModelsLayer;

#nullable disable

namespace P0DbContext
{
    public partial class P0DbContext : DbContext
    {
        public P0DbContext() { }

        public P0DbContext(DbContextOptions<P0DbContext> options) : base(options) { }

        public virtual DbSet<ML.Customer> Customers { get; set; }
        public virtual DbSet<ML.CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<ML.Item> Items { get; set; }
        public virtual DbSet<ML.OrderedItem> OrderedItems { get; set; }
        public virtual DbSet<ML.Store> Stores { get; set; }
        public virtual DbSet<ML.StoredItem> StoredItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=P0Db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ML.Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Pssword)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SignupDate).HasColumnType("date");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ML.CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Customer__C3905BCFB22BF123");

                entity.ToTable("CustomerOrder");

                entity.Property(e => e.OrderCost).HasColumnType("decimal");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Custo__37A5467C");
            });

            modelBuilder.Entity<ML.Item>(entity =>
            {
                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal");
            });

            modelBuilder.Entity<ML.OrderedItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("PK__OrderedI__64B7B3F7B640FE05");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderedIt__ItemI__3F466844");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderedIt__Order__3E52440B");
            });

            modelBuilder.Entity<ML.Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreLocation)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ML.StoredItem>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.StoreId })
                    .HasName("PK__StoredIt__71C6AC9BC4A309A0");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StoredItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoredIte__ItemI__4316F928");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoredItems)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoredIte__Store__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
