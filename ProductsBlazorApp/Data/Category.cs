using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsBlazorApp.Data
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
