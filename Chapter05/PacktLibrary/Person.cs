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
    
}
