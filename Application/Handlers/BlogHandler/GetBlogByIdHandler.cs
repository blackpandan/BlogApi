using BlogApi.Core.Entities;
using BlogApi.Application.Queries.BlogQueries;
using BlogApi.Core.Interfaces;
using System.Threading.Tasks;

namespace BlogApi.Application.Handlers.BlogHandler
{
    public sealed class GetBlogByIdHandler
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<Blog?> HandleAsync(GetBlogByIdQuery query)
        {
            return await _repository.GetByIdAsync(query.BlogId);
        }
    }
}
