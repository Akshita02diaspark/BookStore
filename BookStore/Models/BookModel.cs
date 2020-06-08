using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string  Title { get; set; }
        [Required]

        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required]

        public string TotalPages { get; set; }
        public string Language { get; set; }

    }
}
