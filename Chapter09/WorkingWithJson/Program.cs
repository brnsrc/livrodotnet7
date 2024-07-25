using System.Text.Json;
using WorkingWithJson;
using static System.IO.Path;
using static System.Environment;


Book mybook = new(title: "C# 11 and .NET 7 - Modern Cross-Platform Development Fundamentals"){
    Author = "Mark J Price",
    PublishDate = new(year: 2022, month: 11, day: 8),
    Pages = 823,
    Created = DateTimeOffset.UtcNow
};

System.Console.WriteLine($"Mybook: {mybook.Title}, {mybook.Pages} pages.");
JsonSerializerOptions option = new(){
    IncludeFields = true, //include all fields
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string filePath = Combine(CurrentDirectory, "mybook.json" );
