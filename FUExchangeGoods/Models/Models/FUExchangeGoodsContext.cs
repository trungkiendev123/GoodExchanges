using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Models
{
    public partial class FUExchangeGoodsContext : DbContext
    {
        public FUExchangeGoodsContext()
        {
        }

        public FUExchangeGoodsContext(DbContextOptions<FUExchangeGoodsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FUExchangeGoods;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Buyers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Buyer__UserID__2C3393D0");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cart__UserId__34C8D9D1");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.CartItemId).HasColumnName("CartItemID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartItem__CartID__534D60F1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartItem__Produc__01142BA1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.UserSendNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.UserSend)
                    .HasConstraintName("FK__Contact__UserSen__72C60C4A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.ProductId, "UQ__Order__B40CC6EC820043E9")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Order__BuyerID__5CD6CB2B");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Order)
                    .HasForeignKey<Order>(d => d.ProductId)
                    .HasConstraintName("FK__Order__ProductID__5BE2A6F2");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Order__SellerID__5DCAEF64");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__Order__Transacti__5EBF139D");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DatePosted).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasColumnType("text")
                    .HasColumnName("image");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__3A81B327");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Product__SellerI__398D8EEE");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.ReportDate).HasColumnType("date");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Report__BuyerID__31EC6D26");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Report__SellerID__30F848ED");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Seller__UserID__29572725");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Transacti__Buyer__5629CD9C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Transacti__Produ__5812160E");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Transacti__Selle__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.AccountId, "UK_AccountId")
                    .IsUnique();

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.AccountId)
                    .HasConstraintName("FK__User__AccountId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
