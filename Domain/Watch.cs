using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViktorWatches.Domain
{
    public class Watch
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string WatchName { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufactorer{get;set;}
        [Required]
        public string Description { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Mechanism { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Picture { get; set; }
        [Required]
        [Range(0,5000)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

    }
}
