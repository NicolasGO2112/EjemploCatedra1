
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploCatedra1.src.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string Code { get; set;}

        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [RegularExpression(@"POLERAS|PANTALONES|SOMBREROS")]
        public string Category { get; set; } = string.Empty;
        [Range(1,99)]
        public int Stock { get; set; }
    }
}