using System.ComponentModel.DataAnnotations;

namespace BookRepository.Models
{
    public class CurrentBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titel { get; set; } = string.Empty;

        [Required]
        public string Autor { get; set; } = string.Empty;
    }
}
