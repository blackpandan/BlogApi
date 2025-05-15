using System.ComponentModel.DataAnnotations;

namespace BlogApi.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Blog> Blogs { get; private set; }

        public Author(string name, EmailAddressAttribute email)
        {
            Name = name;
            Email = email;
            Blogs = [];
        }
     }
}