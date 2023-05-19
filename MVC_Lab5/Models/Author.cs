using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab5.Models
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookAuthor> AuthorOfBooks { get; set; } = new HashSet<BookAuthor>();
    }
}
