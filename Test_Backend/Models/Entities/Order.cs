using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Backend.Models.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(20)]
        public string CustomerPhone { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal TotalTax { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
