using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductDetail
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Policy Name")]
        [Required]
        public string ProName { get; set; }
        
        public DateTime PolicyEffectiveDate { get; set; }

        [Required]
        public int Price { get; set; } 
    }
}
