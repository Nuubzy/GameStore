using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$", ErrorMessage = "Card number must be in the format '1234 5678 9012 3456'.")]
        public string Number { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "CVC must be exactly 3 digits.")]
        public string Cvc { get; set; } = string.Empty;

        [Required]
        public CardType Type { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }

    public enum CardType
    {
        Debit,
        Credit
    }
}
