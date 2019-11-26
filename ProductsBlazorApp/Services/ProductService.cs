using Microsoft.EntityFrameworkCore;
using ProductsBlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsBlazorApp.Services
{
    public class ProductService
    {
        private readonly ProductDbContext db;

        // Constructor using dependency injection
        public ProductService(ProductDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of all products</returns>
        public List<Product> GetProducts()
        {
            // Load the categories
            Include(nameof(db.Category));

            return db.Product.ToList();
        }

        /// <summary>
        /// Get a product
        /// </summary>
        /// <param name="id">Id of the product to return</param>
        /// <returns>A product with the provided id or null</returns>
        public Product GetProduct(int id)
        {
            return db.Product.SingleOrDefault(c => c.ProductId == id);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">The product to add</param>
        /// <returns>True if product is added successfuly otherwise false</returns>
        public bool AddProduct(Product product)
        {
            if (product != null)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Id of the product to delete</param>
        /// <returns>True if product is deleted successfuly otherwise false</returns>
        public bool DeleteProduct(int id)
        {
            var product = db.Product.Find(id);
            if (product != null)
            {
                db.Product.Remove(product);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product">product object</param>
        public void UpdateProduct(Product product)
        {
            // Change the state of the product object to modified, so it will be update in database
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Load related navigational properties (eager loading)
        /// </summary>
        /// <param name="property">The navigational property to load</param>
        public void Include(string property)
        {
            var products = db.Product.Include(property);
        }
    }
}
