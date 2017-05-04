namespace WebApiProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BooksDB : DbContext
    {
        public BooksDB()
            : base("name=BooksDB")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Titles)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("AuthorISBN").MapLeftKey("AuthorID").MapRightKey("ISBN"));
        }
    }
}
