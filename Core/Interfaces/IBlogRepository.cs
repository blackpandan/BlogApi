using BlogApi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApi.Core.Interfaces
{
    public interface IBlogRepositiory
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
    }

}