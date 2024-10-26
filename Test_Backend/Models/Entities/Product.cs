using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Backend.Models.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Unit { get; set; }

        [Required]
        public decimal ImportPrice { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxRate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<OrderItem> OrderItems
        {
            get; set;
        }
    }
}
