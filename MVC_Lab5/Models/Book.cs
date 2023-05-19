using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab5.Models
{
    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookId { get; set; }
        [Required,StringLength(20,MinimumLength =3)]
        public string Title { get; set; }

        public string Descrption { get; set; }
        public string PublishedOn { get; set; }     

        public string Publisher { get; set; }

        public int Price { get; set; }
        public string ImageUrl { get; set; }


        public Book ()
        {
            Reviews = new HashSet<Review>();
        }
        public virtual ICollection<Review>Reviews { get; set; }

        public virtual ICollection<Tags> Tag { get; set; } = new HashSet<Tags>();

        public virtual ICollection<BookAuthor> BookAuthor { get; set; } = new HashSet<BookAuthor>();

        public virtual PriceOffers PriceOffers { get; set; }
    }

}
