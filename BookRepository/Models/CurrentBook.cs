using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
