//int a = 3;
//post increment
//int b = a++;
//WriteLine($" a is {a}, b is {b}");

using System.Xml;
using Operators;

int c = 3;
//post increment
int d = ++c;
WriteLine($" a is {c}, b is {d}");

//Boolean
var a = true;
var b = false;

WriteLine($"AND | a | b");
WriteLine($"a | {a & a,-8} | {a & b,-8}");
WriteLine($"a | {a & a,-1} | {a & b,-1}");


Index i1 = new Index(value: 3); // counts from the start 
Index i2 = 3; // using implicit int conversion operator

// two ways to define the same index, 5 in from the end
Index i3 = new Index(value: 5, fromEnd: true);
Index i4 = ^5; // using the caret operator


//Range
Range r1 = new Range(start: new Index(3), end: new Index(7));
Range r2 = new Range(start: 3, end: 7); //using implicit int conversion
Range r3 = 3..7; // using C# 8.0 or later syntax
Range r4 = Range.StartAt(3); // from index 3 to last index
Range r5 = 3..; // from index 3 to last index
Range r6 = Range.EndAt(3); // from index 0 to index 3
Range r7 = ..3; //from index 0 to index 3

//Immutable property
ImmutablePerson jeff = new()
{
    FirstName = "Jeff", //allowed
    LastName = "Winger"
};
//jeff.FirstName = "Geoff"; //Compile error

XmlDocument xmlDoc = new(); // target-typed new in C# 9 or later

//simpler way to define a record
//auto-generates the properties, constructor and deconstructor


Person kim = new();
kim.BirthDate = new(1967, 12, 26); // instead of: new DateTime(1967, 12,26)

public record ImmutableAnimal(string Name, string Species);

// In a separate Person.cs file or at the bottom of Program.cs
class Person
{
    public DateTime BirthDate { get; set; }
}

