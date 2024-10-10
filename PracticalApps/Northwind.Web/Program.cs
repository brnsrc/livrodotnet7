using Microsoft.EntityFrameworkCore.Query;
using Packt.Shared; //AddNorthwindContext extension method
using Microsoft.AspNetCore.Server.Kestrel.Core; //HttpProtocols

//configure services
var builder = WebApplication.CreateBuilder(args);
// builder.WebHost.ConfigureKestrel((context, options) =>
// {
//     options.ListenAnyIP(5001, listenOptions =>
//     {
//         listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
//         listenOptions.UseHttps(); // HTTP/3 requires secure connections
//     });
// });

builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();
var app = builder.Build();

//configure the HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }
    if (context.Request.Path == "/bonjour")
    {
        //in the case of a match on URL path, this becomes a terminating
        //delegate that returns so does not call the next delegate 
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }
    //we could modify the request before calling the next delegate
    await next();

    //we could modify the response before calling the next delegate

});
app.UseHttpsRedirection();
app.UseDefaultFiles(); //index.xhtml, default.xhtml, and so on
app.UseStaticFiles();
app.MapRazorPages();
app.MapGet("/hello", () => "Hello World!");
//start the web server
app.Run();
WriteLine("This executes after the web server has stopped!");