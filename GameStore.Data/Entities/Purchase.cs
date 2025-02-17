using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data.Entities
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$", ErrorMessage = "ProductKey must consist of 3 pairs of 4 uppercase letters or digits, separated by dashes (e.g., ABCD-EFGH-1J3L).")]
        public string ProductKey { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        [ForeignKey("CardId")]
        public Card Card { get; set; } = null!;

        [Required]
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; } = null!;
    }

    public enum PurchaseType
    {
        Retail,
        Digital
    }
}
