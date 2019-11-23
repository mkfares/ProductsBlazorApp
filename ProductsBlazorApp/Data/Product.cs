using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsBlazorApp.Data
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Color { get; set; }
        public bool? IsChecked { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Product")]
        public virtual Category Category { get; set; }
    }
}
