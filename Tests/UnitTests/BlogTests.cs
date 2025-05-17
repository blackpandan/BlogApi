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
using BlogApi.Shared.DTOs;


namespace BlogApi.Tests.UnitTests
{
    public class BlogRepositoryTests
    {
        private readonly ITestOutputHelper _output;

        public BlogRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

        [Fact]
        public async Task GetAllBlogsAsync_ReturnsExpectedBlogs()
        {
            // Arrange
            var mockRepo = new Mock<IBlogRepository>();
            var author = new Author("Faith", "test@gmail.com");

            IEnumerable<BlogDto> expectedblogs =
            [
                new BlogDto {
                    Id = 1,
                    Url = new Uri("http://localhost:5000/Test-Blog"),
                    Title = "Test Blog",
                    AuthorName = author.Name,
                    AuthorEmail = author.Email,
                    DateCreated = DateTime.UtcNow,
                    PostsCount = 2
                },
                new BlogDto {
                    Id = 2,
                    Url = new Uri("http://localhost:5000/Test-Blog"),
                    Title = "Test Blog 2",
                    AuthorName = author.Name,
                    AuthorEmail = author.Email,
                    DateCreated = DateTime.UtcNow,
                    PostsCount = 4
                },
                new BlogDto {
                    Id = 3,
                    Url = new Uri("http://localhost:5000/Test-Blog"),
                    Title = "Test Blog 3",
                    AuthorName = author.Name,
                    AuthorEmail = author.Email,
                    DateCreated = DateTime.UtcNow,
                    PostsCount = 5
                },
                new BlogDto {
                    Id = 4,
                    Url = new Uri("http://localhost:5000/Test-Blog"),
                    Title = "Test Blog 4",
                    AuthorName = author.Name,
                    AuthorEmail = author.Email,
                    DateCreated = DateTime.UtcNow,
                    PostsCount = 5
                },
            ];

            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedblogs);

            //ACT
            var handler = new GetAllBlogsHandler(mockRepo.Object);
            var query = new GetAllBlogsQuery();
            var result = await handler.HandleAsync(query);

            _output.WriteLine(result.ToString() ?? "Result is NULL");
            //Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count());

            var titles = result.Select(b => b.Title).ToList();


            Assert.Contains("Test Blog", titles);
            Assert.Contains("Test Blog 2", titles);
            Assert.Contains("Test Blog 3", titles);
            Assert.Contains("Test Blog 4", titles);

            var expectedTitles = new[] { "Test Blog", "Test Blog 2", "Test Blog 3", "Test Blog 4" };
            Assert.Equal(expectedTitles.OrderBy(t => t), titles.OrderBy(t => t));
        }

        [Fact]
        public async Task GetAllPostsByABlog_ReturnExpectedPosts()
        {
            // Arrange
            var mockRepo = new Mock<IBlogRepository>();
            var author = new Author("Faith", "test@gmail.com");
            var blog = new Blog(new Uri("http://localhost:5000/Test-Blog"),
                "Test Blog",
                author
            );

            IEnumerable<PostDto> expectedPosts = [
                
            ] 
        }
    }
}