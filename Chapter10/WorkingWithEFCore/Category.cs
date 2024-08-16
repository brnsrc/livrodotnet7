using System.ComponentModel.DataAnnotations.Schema;
using Packt.Shared;

namespace WorkingWithEFCore;

public class Category
{
    //these properties map to columns in the database
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    //defines a navigation property for related rows
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        //to enable developers to add products to a category we must
        //initialize the navigation proprty
        Products = new HashSet<Product>();
    }

}
