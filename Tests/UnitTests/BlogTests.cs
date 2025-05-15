using BlogApi.Core.Entities;
using BlogApi.Core.Interfaces;
using BlogApi.Infrastructure.Repositories;
using BlogApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace BlogApi.Tests.UnitTests
{
    public class BlogRepositoryTests
    {
        private readonly BlogApiContext _context;
        private readonly BlogRepository _repository;

        public BlogRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BlogApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new BlogApiContext(options);
            _repository = new BlogRepository(_context);
        }

        [Fact]
        public async Task GetBlogByIdAsync_ReturnsCorrectBlog()
        {
            // Arrange
            var author = new Author ("Faith", "test@gmail.com");
            _context.Authors.Add(author);
            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var blog = new Blog(new Uri("http://localhost:5000/Test-Blog"),
                "Test Blog",
                author
            );
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);
             
            // Act
            var result = await _repository.GetByIdAsync(blog.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Blog", result.Title);
            Assert.Equal(author.Id, result.AuthorId);
        }
    }
}