using Microsoft.EntityFrameworkCore;
using MVC_Lab5.Models;
namespace MVC_Lab5.Models
{
    public class ITIDbContext:DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<BookAuthor> BookAuthor { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<PriceOffers> PriceOffers { get; set; }

        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVC_DataBase;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(a => new {a.BookId , a.AuthorId});


            modelBuilder.Entity<Book>()
                .HasOne(p => p.PriceOffers)
                .WithOne(c => c.Book)
                .HasForeignKey<PriceOffers>(c => c.BookId);


            //modelBuilder.Entity<BookAuthor>()
            // .HasOne(e => e.Book)
            //.WithMany(s => s.BookAuthor)
            // .HasForeignKey(e => e.BookId);

            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(e => e.Author)
            //    .WithMany(c => c.BookAuthor)
            //    .HasForeignKey(e => e.AuthorId);

            //modelBuilder.Entity<BookAuthor>()
            //    .Property(e => e.Order)
            //    .IsRequired();



            //modelBuilder.Entity<Book>()
            //  .HasOne(a => a.PriceOffers)
            //  .WithOne(p => p.Book)
            //  .HasForeignKey<PriceOffers>(p => p.PriceOffersId);


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<MVC_Lab5.Models.BookAuthor> BookAuthor_1 { get; set; }
    }
}
