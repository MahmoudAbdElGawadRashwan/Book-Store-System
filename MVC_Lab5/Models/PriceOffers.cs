using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab5.Models
{
    public class PriceOffers
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PriceOffersId { get; set; }

        public int NewPrice { get; set; }

        public string PromotionalText { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        
        public virtual Book Book { get; set; }
    }
}
