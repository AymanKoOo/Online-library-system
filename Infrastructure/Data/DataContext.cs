using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Core.Entites.Base;
using Core.Entites.Books;
using Core.Entites.Borrowing;
using Core.Entites.Hold;
using System.Reflection.Emit;
using Infrastructure.Seed;
using Core.Entites.Media;

namespace Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BookPicture>().HasKey(sc => new { sc.BookID, sc.PictureId });
            builder.Entity<BookPicture>()
               .HasOne(pt => pt.Book)
               .WithMany(p => p.BookPictures)
               .HasForeignKey(pt => pt.BookID);

            builder.Entity<BookPicture>()
                .HasOne(pt => pt.Picture)
                .WithMany(t => t.BookPictures);

            builder.Seed(); // add roles and admin
        }
        public DbSet<Book> books { get; set; }
        public DbSet<BookPicture> bookPictures { get; set; }
        public DbSet<Borrowing> borrowings { get; set; }
        public DbSet<Hold> holds { get; set; }
        public DbSet<Picture> pictures { get; set; }

    }
}
