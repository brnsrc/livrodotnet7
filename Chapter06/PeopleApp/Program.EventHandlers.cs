using Packt.Shared;
    public partial class Program
    {
        //method to handle the Shout event received by the harry object
        static void Harry_Shout(object? sender, EventArgs e){
            if (sender is null) return;
            Person? p = sender as Person;

            if (p is null) return;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }

        //another method to handle the Shout event received by the harry object
        static void Harry_Shout2(object? sender, EventArgs e){
            if (sender is null) return;
            Person? p = sender as Person;

            if (p is null) return;
            WriteLine($"Stop it!");
        }
    }
