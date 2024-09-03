partial class Program
{
    static void SectionTitle(string title){
        ConsoleColor perviousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        ForegroundColor = perviousColor;        
    }

    static void Output(IEnumerable<string> cohort, string description = ""){
        if (!string.IsNullOrEmpty(description))
        {
            WriteLine(description);
        }
        Write(" ");
        WriteLine(string.Join(", ", cohort.ToArray()));
        WriteLine();
    }
}
