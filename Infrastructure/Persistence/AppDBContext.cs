using Microsoft.EntityFrameworkCore;
using BlogApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace BlogApi.Infrastructure.Persistence
{
    public class BlogApiContext(DbContextOptions<BlogApiContext> options) : DbContext(options)
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BLOG
            modelBuilder.Entity<Blog>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("datetime('now')");

            //POST
            modelBuilder.Entity<Post>()
                .Property(b => b.DatePublished)
                .HasDefaultValueSql("datetime('now')");

            // AUTHOR
            modelBuilder.Entity<Author>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("datetime('now')");

            // Relationships
            modelBuilder.Entity<Blog>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Blogs)
            .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogId);
        }
     }

}