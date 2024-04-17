using static System.Console;
static void SwitchCase()
{
    int number = Random.Shared.Next(1, 7);
    System.Console.WriteLine($"My random number is {number}");
    switch (number)
    {
        case 1:
            System.Console.WriteLine("One");
            break;
        case 2:
            System.Console.WriteLine("Two");
            break;
        case 3: //multiple case section
        case 4:
            System.Console.WriteLine("Three or four");
            break;
        case 5:
            goto A_label;
        default:
            System.Console.WriteLine("Default");
            break;
    } // end of switch statement
    System.Console.WriteLine("After and of switch");
A_label:
    System.Console.WriteLine($"After A_label");
}

static void PatternMatching()
{
    object o = 3;
    int j = 4;
    //Caso a variável 'o' seja um int, a variável i receberá o valor de 'o'
    if (o is int i)
    {
        System.Console.WriteLine($"{i} x {j} = {i * j}");
    }
    else
    {
        System.Console.WriteLine("o is not an int so it cannot multiply!");
    }
}

static void SwitchPatternMatching()
{
    string path = @"C:\Users\BrunoSouza-Desk\Documents\Code\livrodotnet7\chapter03\Selection\pattern-matching";
    Stream? s;
    Write("Press R for read-only or W for writeable: ");
    ConsoleKeyInfo key = ReadKey();

    if (key.Key == ConsoleKey.R)
    {
        s = File.Open(Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate, FileAccess.Read);
    }
    else
    {
        s = File.Open(Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate, FileAccess.Write);
    }
    WriteLine();
    string message;
    switch (s)
    {
        case FileStream writeableFile when s.CanWrite:
            message = "The Stream is a file that i can write to.";
            break;
        case FileStream readOnlyFile:
            message = "The stream is a read-only file.";
            break;
        case MemoryStream ms:
            message = "The Stream is a memory address.";
            break;
        default: // always evaluated last despite its current position
            message = "Te stream is some other type";
            break;
        case null:
            message = "The stream is null";
            break;

    }
    WriteLine(message);

}

static void SwitchInCSharp8()
{
    string path = @"C:\Users\BrunoSouza-Desk\Documents\Code\livrodotnet7\chapter03\Selection\pattern-matching";
    Stream? s;
    Write("Press R for read-only or W for writeable: ");
    ConsoleKeyInfo key = ReadKey();

    if (key.Key == ConsoleKey.R)
    {
        s = File.Open(Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate, FileAccess.Read);
    }
    else
    {
        s = File.Open(Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate, FileAccess.Write);
    }
    WriteLine();
    string message;
    message = s switch
    {
        FileStream writeableFile when s.CanWrite =>
            "The Stream is a file that i can write to.",
        FileStream readOnlyFile =>
            "The stream is a read-only file.",
        MemoryStream ms =>
            "The Stream is a memory address.",
        null =>
            "The stream is null",
        _ => "Te stream is some other type"
    };
    WriteLine(message);
}

SwitchInCSharp8();