using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsBlazorApp.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Female = 1,

        Male
    }
}
