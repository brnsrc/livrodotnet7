using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using WorkingWithEFCore;

partial class Program
{
    static void QueryCategories()
    {
        using (Northwind db = new())
        {
            SectionTitle("Categories and how many products they have:");
            //query to get all categories and their related products
            IQueryable<Category>? categories =
                db.Categories?.Include(c => c.Products);
            if (categories is null)
            {
                Fail("No categories found.");
                return;
            }
            //execute query and enumerate results
            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }
    }
}
