using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }
        public DateTime DateCreated { get; set; }
        // TODO: add sql trigger to update data on modification 
        // public DateTime LastUpdated { get; set; }
        public int AuthorId { get; set; }
        public virtual ICollection<Post> Posts { get; private set; }
        public Author Author { get; private set; }


        public Blog(Uri url, string title, Author author)
        {
            Url = url;
            Title = title;
            Author = author;
            Posts = [];
        }

     }
}