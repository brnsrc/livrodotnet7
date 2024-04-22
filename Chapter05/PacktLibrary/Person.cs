namespace Packt.Shared;
public class Person
{
    public string? Name { get; set; }
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();
    public const string Species = "Homo Sapiens";

    //read-only
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    //constructor
    public Person()
    {
        //set default values for fields
        //including read-only fields
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Numbre: 5);
    }

    //deconstructor
    public void Deconstruct(out string? name, out DateTime dob){
        name =Name;
        dob = DateOfBirth;
    }

    public void Deconstruct(ou string? name, out DateTime dob, out WondersOfTheAncientWorld fav){
        name = Name;
        dob = DateOfBirth;
        fav = FavoriteAncientWonder;
    }
}
