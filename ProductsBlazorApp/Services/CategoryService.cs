using ProductsBlazorApp.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductsBlazorApp.Services
{
    public class CategoryService
    {
        // Instance of the db context
        private readonly ProductDbContext db;

        // Constructor using dependency injection
        public CategoryService(ProductDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of all categories</returns>
        public List<Category> GetCategories()
        {
            return db.Category.ToList();
        }

        /// <summary>
        /// Get a category
        /// </summary>
        /// <param name="id">Id of the category to return</param>
        /// <returns>A category with the provided id or null</returns>
        public Category GetCategory(int id)
        {
            return db.Category.SingleOrDefault(c => c.CategoryId == id);
        }

        /// <summary>
        /// Add a new category
        /// </summary>
        /// <param name="category">The category to add</param>
        /// <returns>True if category is added successfuly otherwise false</returns>
        public bool AddCategory(Category category)
        {
            if (category != null)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id">Id of the category to delete</param>
        /// <returns>True if category is deleted successfuly otherwise false</returns>
        public bool DeleteCategory(int id)
        {
            var category = db.Category.Find(id);
            if (category != null)
            {
                db.Category.Remove(category);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category">category object</param>
        public void UpdateCategory(Category category)
        {
            // Change the state of the category object to modified, so it will be update in database
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
