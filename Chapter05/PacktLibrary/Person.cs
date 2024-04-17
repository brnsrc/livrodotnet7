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

}
