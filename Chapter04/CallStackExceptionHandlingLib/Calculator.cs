using static System.Console;

namespace CallStackExceptionHandlingLib;

public class Calculator{
    //public so it ca be called from outside
    public static void Gamma(){
        WriteLine("In Gamma");
        Delta();
    }

    //private so it can be only be called internally
    private static void Delta()
    {
        WriteLine("in Delta");
        File.OpenText("bad file path");
    }
}
