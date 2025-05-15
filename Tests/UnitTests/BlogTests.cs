using BlogApi.Core.Entities;
using BlogApi.Core.Interfaces;
using BlogApi.Infrastructure.Repositories;
using BlogApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using BlogApi.Application.Handlers.BlogHandler;
using BlogApi.Application.Queries.BlogQueries;


namespace BlogApi.Tests.UnitTests
{
    public class BlogRepositoryTests
    {

        [Fact]
        public async Task GetBlogByIdAsync_ReturnsCorrectBlog()
        {
            // Arrange
            var mockRepo = new Mock<IBlogRepository>();

            int blogId = 1;
            var author = new Author("Faith", "test@gmail.com");
            var expectedBlog = new Blog(new Uri("http://localhost:5000/Test-Blog"),
                "Test Blog",
                author
            );

            mockRepo.Setup(repo => repo.GetByIdAsync(blogId)).ReturnsAsync(expectedBlog);

            var handler = new GetBlogByIdHandler(mockRepo.Object);
            var query = new GetBlogByIdQuery(blogId);
            // _context.Authors.Add(author);
            // await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // var blog = new Blog(new Uri("http://localhost:5000/Test-Blog"),
            //     "Test Blog",
            //     author
            // );
            // _context.Blogs.Add(blog);
            // await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await handler.HandleAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Blog", result.Title);
            Assert.Equal(author.Id, result.AuthorId);
        }
    }
}