using System.Threading.Tasks;
using BlogApi.Core.Interfaces;


namespace BlogApi.Presentation.Endpoints
{
    public static class BlogEndpoints
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("blog/{id}", async (IBlogRepository repo, int id) =>
            {
                var blog = await repo.GetByIdAsync(id);
                return blog is not null ? Results.Ok(blog) : Results.NotFound();
            });
        }
    }
}