using Packt.Shared; //AddNorthwindContext extension method

//configure services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();
var app = builder.Build();

//configure the HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseDefaultFiles(); //index.xhtml, default.xhtml, and so on
app.UseStaticFiles();
app.MapRazorPages();
app.MapGet("/hello", () => "Hello World!");
//start the web server
app.Run();
WriteLine("This executes after the web server has stopped!");