using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DAL
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
