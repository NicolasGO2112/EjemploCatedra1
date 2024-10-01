using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploCatedra1.src.Dtos
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Code { get; set;}

       
        public required string Name { get; set; }

        [RegularExpression(@"POLERAS|PANTALONES|SOMBREROS")]
        public required string Category { get; set; }

        [Range(1,99)]
        public int Stock { get; set; }
    }
}