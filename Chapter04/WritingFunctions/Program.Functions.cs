partial class Program
{
    public static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows: ");
        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();
    }

    public static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        decimal rate = 0.0M;
        switch (twoLetterRegionCode)
        {
            case "CH": //Switzerland
                rate = 0.08M;
                break;

            case "DK": //Denmark
            case "NO": //Norway
                rate = 0.25M;
                break;

            case "GB": //United Kingdon
            case "FR": //France
                rate = 0.2M;
                break;

            case "HU": //Hungary
                rate = 0.27M;
                break;

            case "OR": //Oregon
            case "AK": //Alaska
            case "MT": //Montana
                rate = 0.0M;
                break;

            case "ND": //North Dakota
            case "WI": //Winsconsin
            case "ME": //Maine
            case "VA": //Virginia
                rate = 0.05M;
                break;

            case "CA": //California
                rate = 0.0825M;
                break;

            default: //most US states
                rate = 0.06M;
                break;

        }

        return amount * rate;
    }

    /// <summary>
    /// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
    /// </summary>
    /// <param name="number">Number as a cardinal value e.g 1,2,3, and so on.</param>
    /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
    public static string CardinalToOrdinal(int number)
    {
        switch (number)
        {
            case 11: //special cases for 11th to 13th
            case 12:
            case 13:
                return $"{number}th";

            default:
                int lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th"
                };
                return $"{number}{suffix}";
        }
    }

    public static void RunCardinalToOrdinal()
    {
        for (int number = 1; number <= 40; number++)
        {
            Write($"{CardinalToOrdinal(number)} ");
        }
        WriteLine();
    }


    static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException(message:
                "The factorial function is defined for non-negative integers only.", paramName: "number");
        }
        else if (number == 0)
        {
            return 1;
        }
        checked
        {
            return number * Factorial(number - 1);
        }
    }

    static void RunFactorial()
    {
        for (int i = 1; i <= 14; i++)
        {
            try
            {

                WriteLine($"{i}! = {Factorial(i):N0}");
            }

            catch (System.OverflowException)
            {
                WriteLine($"{i} is too big for a 32-bit integer.");
            }
        }
    }

    static int FibImperative(int term)
    {
        if (term == 1)
        {
            return 0;
        }
        else if (term == 2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term - 1) + FibImperative(term - 2);
        }
    }

    static void RunFibImperative()
    {
        for (int i = 0; i <= 30; i++)
        {
            WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
            arg0: CardinalToOrdinal(i), arg1: FibImperative(term: 1));

        }
    }

    static void TimeTable2(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times tables with {size} rows: ");
        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();

    }
}
