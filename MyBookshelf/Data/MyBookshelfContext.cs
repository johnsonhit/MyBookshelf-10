using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBookshelf.Data
{
    public partial class MyBookshelfContext : DbContext
    {
        public MyBookshelfContext()
        {
        }

        public MyBookshelfContext(DbContextOptions<MyBookshelfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.AuthorName).HasMaxLength(50);

                entity.Property(e => e.BookGenre).HasMaxLength(50);

                entity.Property(e => e.BookName).HasMaxLength(50);

                entity.Property(e => e.DateAdd).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}