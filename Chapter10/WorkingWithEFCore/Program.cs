using Packt.Shared;
// Northwind db = new();
// WriteLine($"Provider: {db.Database.ProviderName}");

// QueryCategories();
// FilteredIncludes();
// QueryingProducts();
// QueryingWithLike();
// GetRandomProduct();
// var resulAdd = AddProduct(categoryId: 6, productName: "Bob's Burguers", price: 500M);
// if (resulAdd.affected == 1)
// {
//     WriteLine("Add product successful.");
// }
// ListProdcuts(productIdToHighLight: resulAdd.ProductId);

// var resultUpdate = IncreaseProductPrice(productNameStartWith: "Bob", amount: 20M);
// if (resultUpdate.affected == 1)
// {
//     WriteLine("Increase product price successful.");
// }
// ListProdcuts(productIdToHighLight: resultUpdate.productId);

WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProducts(productNameStartWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}else{
    WriteLine("Deleted was cancelled.");
}