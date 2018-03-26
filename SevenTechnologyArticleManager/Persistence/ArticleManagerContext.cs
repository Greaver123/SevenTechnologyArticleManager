namespace SevenTechnologyArticleManager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArticleManagerContext : DbContext
    {
        public ArticleManagerContext()
            : base("name=ArticleManagerContext")
        {
        }

        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceList>()
                .ToTable("Cenniki")
                .Property(e => e.Name)
                .HasColumnName("Nazwa")
                .IsUnicode(false);

            modelBuilder.Entity<PriceList>()
                .Property(e => e.DateFrom)
                .HasColumnName("Data_Od");

            modelBuilder.Entity<PriceList>()
                .Property(e => e.DateTo)
                .HasColumnName("Data_Do");

            modelBuilder.Entity<PriceList>()

                .HasMany(e => e.Prices)
                .WithOptional(e => e.PriceList)
                .HasForeignKey(e => e.PriceListId);

            modelBuilder.Entity<Price>()
                .ToTable("Ceny")
                .Property(e => e.ProductPrice)
                .HasColumnName("Cena")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Price>()
                .Property(e => e.PriceListId)
                .HasColumnName("CennikId");

            modelBuilder.Entity<Price>()
                .Property(e => e.ProductId)
                .HasColumnName("TowarId");

            modelBuilder.Entity<Price>()
                .Property(e => e.Discount)
                .HasColumnName("Rabat")
                .HasPrecision(5, 2);

            modelBuilder.Entity<Product>()
                .ToTable("Towary")
                .Property(e => e.Code)
                .HasColumnName("Kod")
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasColumnName("Nazwa")
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Mass)
                .HasColumnName("Masa")
                .HasPrecision(14, 3);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitOfMass)
                .HasColumnName("JM")
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.DateOfCreation)
                .HasColumnName("Data_Utworzenia");

            modelBuilder.Entity<Product>()
                .Property(e => e.DateOfModification)
                .HasColumnName("Data_Modyfikacji");


            modelBuilder.Entity<Product>()
                .HasMany(e => e.Prices)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
