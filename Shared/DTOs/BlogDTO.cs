namespace BlogApi.Shared.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public Uri Url { get; set; } = new Uri("http://default.com");
        public DateTime DateCreated { get; set; }
        public string AuthorEmail { get; set; } = string.Empty;
        public int PostsCount { get; set; }
    }
}
