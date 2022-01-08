using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class BicycleType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
