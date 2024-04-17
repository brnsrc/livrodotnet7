using System.Xml.XPath;
using static System.Console;
CheckingOveflow();

static void CheckingOveflow()
{
    // try
    // {
    //     checked
    //     {
    //         int x = int.MaxValue - 1;
    //         WriteLine($"Initial Value: {x}");
    //         x++;

    //         WriteLine($"After Incrementing: {x}");
    //         x++;
    //         WriteLine($"After Incrementing: {x}");
    //         x++;
    //         WriteLine($"After Incrementing: {x}");
    //     }
    // }
    // catch (OverflowException)
    // {
    //     WriteLine("The code overflowed but i caught the exception.");
    // }

    // WriteLine($"--------------------------------------");
    // unchecked
    // {
    //     int y = int.MaxValue + 1;
    //     WriteLine($"Initial Value: {y}");
    //     y--;
    //     WriteLine($"After decrementing: {y}");
    //     y--;
    //     WriteLine($"After decrementing: {y}");

    // }
    decimal y = 10;
    var resul = y / 0;
    WriteLine($"resul: {resul}");


}