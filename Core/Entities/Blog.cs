using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlogApi.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        // TODO: add sql trigger to update data on modification 
        // public DateTime LastUpdated { get; set; }
        public int AuthorId { get; set; }
        public virtual ICollection<Post> Posts { get; private set; }
        public Author Author { get; private set; }


        public Blog(Uri url, string title, Author author)
        {
            Url = url;
            Title = title;
            Author = author ?? throw new ArgumentNullException(nameof(author));
            AuthorId = author.Id;
            Posts = [];
        }
        
        public Blog() {}

     }
}