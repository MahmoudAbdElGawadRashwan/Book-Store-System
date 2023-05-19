using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab5.Models
{
    public class BookAuthor
    {

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public int Order { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }


    }
}
