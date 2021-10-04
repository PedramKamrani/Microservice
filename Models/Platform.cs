using System.ComponentModel.DataAnnotations;

namespace platformService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}