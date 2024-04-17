using static System.Console;
static void TestLooping()
{
    int wrong = 0;
    string? password;
    do
    {
        Write("Enter your password: ");
        password = ReadLine();
        wrong++;
        if (wrong >= 3)
            break;

    } while (password != "123");

    if (password == "123")
        WriteLine("Correct!");
    else
        WriteLine("Wrong!");
}

TestLooping();