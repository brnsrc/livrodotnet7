using Microsoft.EntityFrameworkCore; //for GenerateCreateScript()
using Packt.Shared;

using (Academy a = new())
{
    bool deleted = await a.Database.EnsureDeletedAsync();
    WriteLine($"Databae deleted:{deleted}");

    bool created = await a.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL Script to created database:");
    WriteLine(a.Database.GenerateCreateScript());
    foreach (Student s in a.Students.Include(s => s.Courses))
    {
        WriteLine("{0} {1} attends the following {2} courses:", s.FirstName, s.LastName,
            s.Courses.Count);
        foreach (Course c in s.Courses)
        {
            WriteLine($"    {c.Title}");
        }
    }
}
