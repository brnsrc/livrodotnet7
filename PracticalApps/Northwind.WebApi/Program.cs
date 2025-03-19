using Microsoft.AspNetCore.Mvc.Formatters; //IOutputFormatter, OutputFormatter
using Packt.Shared; //AddNorthWindContext extension methods
using Northwind.WebApi.Repositories; //ICustomerRepository, CustomerRepository
using Swashbuckle.AspNetCore.SwaggerUI;
using Northwind.WebApi; //SubmitMethod
using Microsoft.AspNetCore.Server.Kestrel.Core; //HttpProtocols

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddNorthwindContext();

builder.Services.AddControllers(
    options =>
    {
        WriteLine("Default output formatters:");
        foreach (IOutputFormatter formatter in options.OutputFormatters)
        {
            OutputFormatter? mediaFormatter = formatter as OutputFormatter;
            if (mediaFormatter is null)
            {
                WriteLine($"    {formatter.GetType().Name}");
            }
            else //OutputFormatter class has SupportedMediaTypes
            {
                WriteLine(" {0}, Media types: {1}",
                    arg0: mediaFormatter.GetType().Name,
                    arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
            }
        }
    }
).AddXmlDataContractSerializerFormatters().AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddHealthChecks().AddDbContextCheck<NorthwindContext>();

builder.WebHost.ConfigureKestrel((context, optons) =>
{
    optons.ListenAnyIP(5002, ListenOptions => {
        ListenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        ListenOptions.UseHttps(); // HTTP/3 require secure connections
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //config. padrão foi o suficiente nos testes com delaração "app.UseSwaggerUI();" 
    //config abaixo apenas para seguir o livro   
    app.UseSwaggerUI( c =>         
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind Service API Version 1");
        c.SupportedSubmitMethods(new[]
        {
            SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete    
        });
    });    
}

app.UseHttpsRedirection();
app.UseAuthorization();

//to verify health check api
app.UseHealthChecks(path:"/howdoyoufeel");

app.UseMiddleware<SecurityHeaders>();
app.MapControllers();
app.Run();
