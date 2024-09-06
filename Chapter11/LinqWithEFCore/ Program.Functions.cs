
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
partial class Program
{
    static void FilterAndSort()
    {
        SectionTitle("Filter and sort");
        using (Northwind db = new())
        {
            DbSet<Product> allProducts = db.Products;
            IQueryable<Product> filteredProducts =
                allProducts.Where(
                product => product.UnitPrice < 10M);
            IOrderedQueryable<Product> sortedAndFilteredProducts =
                filteredProducts.OrderByDescending(
                product => product.UnitPrice);
            WriteLine("Products that cost less than $10:");
            foreach (Product p in sortedAndFilteredProducts)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}", p.ProductId,
                    p.ProductName, p.UnitPrice);
            }
            WriteLine();
            WriteLine(sortedAndFilteredProducts.ToQueryString());
        }


    }
}
