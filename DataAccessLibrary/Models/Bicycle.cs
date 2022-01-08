using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Bicycle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        //[Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        public BicycleType BicycleType { get; set; }

        [Required]
        public decimal RentPrice { get; set; }

        [Required]
        public bool IsRented { get; set; }


    }
}
