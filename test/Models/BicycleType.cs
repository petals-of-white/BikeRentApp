using System.ComponentModel.DataAnnotations;
namespace test.Models
{
    public class BicycleType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
