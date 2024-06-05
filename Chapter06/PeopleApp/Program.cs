using Packt.Shared;
Person harry = new()
{
    Name = "Harry",
    DateOfBirth = new(year: 2001, month: 3, day: 25)
};
harry.WriteToConsole();

//non-generic lookup collection
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2;
WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupObject[key]);

//look up the value that has harry as its key
WriteLine(format: "key {0} has value {1}", arg0: harry, arg1: lookupObject[harry]);

//generic lookup collection
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Betaa");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupIntString[key]);


//assign an event handler methods to Shout event
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout2;

//call the poke method that raises the Shout event
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

Person?[] people = {
    null,
    new() {Name = "Simon"},
    new() {Name = "Jenny"},
    new() {Name = "Adam"},
    new() {Name = null},
    new() {Name = "Richard"}
};

OutputPeopleNames(people, "Initial list of people:");
Array.Sort(people);
OutputPeopleNames(people, "After sorting using Person's IComparable implementaion:");


Array.Sort(people, new PersonComparer());
OutputPeopleNames(people, "After sorting using PersonComparer's IComparer implementation:");

int a = 3;
int b = 3;

WriteLine($"a: {a}, b:{b}");
WriteLine($"a == b: {a == b}");

Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };

WriteLine($"p1: {p1}, bp2:{p2}");
WriteLine($"p1 == p2: {p1 == p2}");

Person p3 = p1;
WriteLine($"p3: {p3}");
WriteLine($"p1 == p3: {p1 == p3}");

WriteLine($"p1.Name: {p1.Name}, p2.Name:{p2.Name}");
WriteLine($"p1.Name == p2.Name: {p1.Name == p2.Name}");

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;

WriteLine($"({dv1.x}, {dv1.y} + {dv2.x}, {dv2.y} = ({dv3.x}, {dv3.y})");

DisplacementVector dv4 = new();
WriteLine($"{dv4.x}, {dv4.y}");

Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};

// john.WriteToConsole();
// john.EmployeeCode = "JJ001";
// john.HireDate = new(year: 2014, month: 11, day: 23);
// WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

Employee aliceInEmployee = new()
{ Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

if (aliceInPerson is Employee)
{
    WriteLine($"{nameof(aliceInPerson)} IS an employee.");
    Employee exlpicitAlice = (Employee)aliceInPerson;
    //safely do something with explicitAlice
}

if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} IS an employee");
}

Employee? aliceAsEmployee = aliceInPerson as Employee; //could be null
if (aliceAsEmployee is not null)
{
    WriteLine($"{nameof(aliceInPerson)} AS an employee");
    //safely do something with aliceAsEmployee
}

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{

    WriteLine(ex.Message);
}

string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine("{0} is a valid e-mail address: {1}",
    arg0: email1, arg1: StringExtensions.IsValidEmail(email1));
WriteLine("{0} is a valid e-mail address: {1}",
    arg0: email2, arg1: StringExtensions.IsValidEmail(email2));


WriteLine("{0} is a valid e-mail address: {1}",
    arg0: email1, arg1: email1.IsValidEmail());
WriteLine("{0} is a valid e-mail address: {1}",
    arg0: email2, arg1: email2.IsValidEmail());