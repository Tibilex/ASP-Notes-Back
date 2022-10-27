using System.ComponentModel.DataAnnotations;

namespace QueryLibrary.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Label { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string? Text { get; set; }
    }
}
