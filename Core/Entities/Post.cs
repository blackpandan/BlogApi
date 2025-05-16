using System.ComponentModel.DataAnnotations;

namespace BlogApi.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public int AuthorId { get; set; }
        public int BlogId { get; init; }
        public Author Author { get; private set; }
        public Blog Blog { get; private set; }

        public Post(string title, string content, Blog blog, Author author)
        {
            Content = content;
            Title = title;
            Blog = blog;
            Author = author;
        }
    }
}