using Microsoft.EntityFrameworkCore; //for GenerateCreateScript()
using Packt.Shared;

using (Academy a = new())
{
    bool deleted = await a.Database.EnsureDeletedAsync();
    WriteLine($"Databae deleted:{deleted}");

    bool created = await a.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");
}
