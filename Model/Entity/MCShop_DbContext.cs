using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.Entity
{
    public partial class MCShop_DbContext : DbContext
    {
        public MCShop_DbContext()
            : base("name=MCShop_DbContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTS { get; set; }
        public virtual DbSet<CATEGORY> CATEGORIES { get; set; }
        public virtual DbSet<ORDER_DETAILS> ORDER_DETAILS { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<PROFILE> PROFILES { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.PERMISSION)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.PROFILES)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.PRODUCTS)
                .WithRequired(e => e.CATEGORy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<PROFILE>()
                .Property(e => e.PHONENUMBER)
                .IsUnicode(false);
        }
    }
}
