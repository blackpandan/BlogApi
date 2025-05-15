using BlogApi.Core.Entities;
using BlogApi.Core.Interfaces;
using BlogApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogApiContext _context;

        public BlogRepository(BlogApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs.Include(b => b.Author).Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == id);
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
