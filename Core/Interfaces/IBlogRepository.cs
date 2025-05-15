using BlogApi.Shared.DTOs;
using BlogApi.Core.Entities;


namespace BlogApi.Core.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
    }

}