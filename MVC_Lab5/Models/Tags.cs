using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab5.Models
{
    public class Tags
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagID { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Book> Book { get; set; } = new HashSet<Book>();
    }
}
