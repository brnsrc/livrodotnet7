using System.Xml.Serialization; //XmlSerialization
using Packt.Shared; //Person
using static System.Environment;
using static System.IO.Path;

//create an object graph
List<Person> people = new(){
    new(30000M){
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth= new (year: 1974, month: 3, day: 14)
    },
    new(40000M){
        FirstName = "Bob",
        LastName= "Jones",
        DateOfBirth= new (year: 1969, month: 11, day: 23)
    },
    new(20000M){
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new (year: 1984, month: 5, day: 4),
        Children = new(){
            new(0M){
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(year: 2012, month: 7, day: 12)
            }
        }
    }
};

//create object that will format a list of Persons as XML
XmlSerializer xs = new(type: people.GetType());
//create a file to write to
string path = Combine(CurrentDirectory, "people.xml");
using (FileStream stream = File.Create(path))
{
    //serialize the object graph to the stream
    xs.Serialize(stream, people);
}
WriteLine("Written {0:N0} bytes of XML to {1}",
    arg0: new FileInfo(path).Length, arg1: path);
WriteLine();
//Display the serialized object graph
WriteLine(File.ReadAllText(path));


