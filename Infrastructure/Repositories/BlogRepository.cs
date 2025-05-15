using BlogApi.Shared.DTOs;
using BlogApi.Core.Entities;
using BlogApi.Core.Interfaces;
using BlogApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogApiContext _context;

        public BlogRepository(BlogApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {

            return await _context.Blogs
                .Select(b => new BlogDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorName = b.Author.Name,
                    AuthorEmail = b.Author.Email,
                    PostsCount = b.Posts.Count()
                })
                .ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Posts)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
