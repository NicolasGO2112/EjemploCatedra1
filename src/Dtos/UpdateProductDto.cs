using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploCatedra1.src.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        public required string Code { get; set;}
        
        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }

        [RegularExpression(@"POLERAS|PANTALONES|SOMBREROS")]
        public required string Category { get; set; }

        [Range(1,99)]
        public int Stock { get; set; }
    }
}