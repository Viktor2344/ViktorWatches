using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViktorWatches.Domain
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        [MinLength(30)]
        public string ManufacturerName { get; set; }
        public virtual IEnumerable<Watch> Watches { get; set; } = new List<Watch>(); // поправено
    }
}
