using BlogApi.Core.Entities;
using BlogApi.Application.Queries.BlogQueries;
using BlogApi.Core.Interfaces;
using System.Threading.Tasks;
using BlogApi.Shared.DTOs;

namespace BlogApi.Application.Handlers.BlogHandler
{
    public sealed class GetAllBlogsHandler
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BlogDto>> HandleAsync(GetAllBlogsQuery query)
        {
            return await _repository.GetAllAsync();
        }
    }
}
