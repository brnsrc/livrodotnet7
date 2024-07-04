partial class Program
{
    static void Output(string title, IEnumerable<string> collection){
        WriteLine(title);
        foreach (string item in collection)
        {
            WriteLine($"    {item}");
        }
    }
}
