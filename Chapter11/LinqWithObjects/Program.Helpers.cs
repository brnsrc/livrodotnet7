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
}
