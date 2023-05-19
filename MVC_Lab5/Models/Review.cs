using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab5.Models
{
    public class Review
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReviewId { get; set; }

        public string VoterName { get; set; }

        public int NumStars { get; set; }

        public string Comment { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

        
        public virtual Book Book { get; set; }

    }
}
