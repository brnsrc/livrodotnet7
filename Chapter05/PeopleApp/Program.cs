﻿using Packt.Shared;

Person bob = new();
bob.Name = "Bob";
bob.DateOfBirth = new DateTime(1965, 12, 22);

WriteLine(format:
   "{0} was born on {1:dddd, d MMMM yyyy}",
    arg0: bob.Name,
    arg1: bob.DateOfBirth);

Person alice = new()
{
   Name = "Alice Jone",
   DateOfBirth = new(1998, 3, 7) //C# 9.0 or later
};

WriteLine(format: "{0} was born on {1:dd MMM yy}",
   arg0: alice.Name,
   arg1: alice.DateOfBirth);

bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
WriteLine(
   format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
   arg0: bob.Name,
   arg1: bob.FavoriteAncientWonder,
   arg2: (int)bob.FavoriteAncientWonder);

bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon |
   WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
// bob.BucketList = (WondersOfTheAncientWorld)18;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

bob.Children.Add(new Person { Name = "Alfred" }); //C# 3.0 and later
bob.Children.Add(new() { Name = "Zoe" }); //C# 9.0 and later
WriteLine($"{bob.Name} has {bob.Children.Count} children:");
for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
{
   WriteLine($"> {bob.Children[childIndex].Name}");
}

BankAccount.InterestRate = 0.012M; //store shared value
BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;

WriteLine(format: "{0} earned {1:C} interest.",
   arg0: jonesAccount.AccountName,
   arg1: jonesAccount.Balance * BankAccount.InterestRate);

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-GB");
BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} ineterest.",
   arg0: gerrierAccount.AccountName,
   arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine($"{bob.Name} is a {Person.Species}");

WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
Person blankPerson = new();
WriteLine(format:
   "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
   arg0: blankPerson.Name,
   arg1: blankPerson.HomePlanet,
   arg2: blankPerson.Instantiated);


Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(format:
  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
  arg0: gunny.Name,
  arg1: gunny.HomePlanet,
  arg2: gunny.Instantiated);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

(string, int) fruit = bob.GetFruit();
var fruitNamed = bob.GetNamedFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
WriteLine($"There are {fruitNamed.Number}, {fruitNamed.Name}.");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

//Deconstructing a Person
var (name1, dob1) = bob; //implicitly calls the deconstruct method
WriteLine($"Deconstructed: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5));
WriteLine(bob.OptionalParameters("Poke!", active: false));

int a = 10;
int b = 20;
int c = 30;
WriteLine($"Before: a = {a}, b = {b}, c = {c}");
bob.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");

int d = 10;
int e = 20;

WriteLine($"Before: d = {d}, e = {e}, f doesn't exists yet!");

//simplified c# 7.0 or latersyntax for the out parameter
bob.PassingParameters(d, ref e, out int f);
WriteLine($"After: d = {d}, e = {e}, f = {f}");

Person sam = new()
{
   Name = "Sam",
   DateOfBirth = new(1969, 6, 25)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
sam.FavoritePrimaryColor = "Red";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoritePrimaryColor}.");


Book book = new();
book.Title = "C# 11 and .NET 7 - Modern Cross-Platform Development";

WriteLine($"book.Title: {book.Title}");

sam.Children.Add(new() { Name = "Charlie", DateOfBirth = new(2010, 3, 18) });
sam.Children.Add(new() { Name = "Ella", DateOfBirth = new(2020, 12, 24) });

//get using Children list
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}.");

//get using integer position indexer
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");

//get using name indexer
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old");


Person lamech = new(){Name = "Lamech"};
Person adah = new(){Name = "Adah"};
Person zillah = new(){Name = "Zillah"};

lamech.Marry(adah);

// Person.Marry(zillah, lamech);
if (zillah + lamech)
{
   WriteLine($"{zillah.Name} and {lamech.Name} successfully got married.");
}
WriteLine($"{lamech.Name} is married to {lamech.Spouse?.Name ?? "nobody"}");
WriteLine($"{adah.Name} is married to {adah.Spouse?.Name ?? "nobody"}");
WriteLine($"{zillah.Name} is married to {zillah.Spouse?.Name ?? "nobody"}");

//call instance method
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.DateOfBirth}");

//call static method
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

//use operator to "multiply"
Person baby3 = lamech * adah;
baby3.Name = "Jubal";
Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

WriteLine($"{lamech.Name} has {lamech.Children.Count} children.");
WriteLine($"{adah.Name} has {adah.Children.Count} children.");
WriteLine($"{zillah.Name} has {zillah.Children.Count} children.");

for (int i = 0; i < lamech.Children.Count; i++)
{
   WriteLine(format:"{0}'s child #{1} is named \"{2}\".", arg0: lamech.Name, arg1: i, arg2: lamech[i].Name);
}

WriteLine($"5! is {Person.Factorial(5)}");


Passenger[] passengers = {
   new FirstClassPassenger {AirMiles = 1_419, Name = "Suman"},
   new FirstClassPassenger {AirMiles = 16_562, Name = "Lucy"},
   new BusinessClassPassenger {Name = "Janice"},
   new CoachClassPassenger {CarryOnKG = 25.7, Name = "Dave"},
   new CoachClassPassenger {CarryOnKG = 0, Name = "Amit"},
};

foreach (Passenger passenger in passengers)
{
   decimal flightCost = passenger switch
   {
      //C# 8 syntax
      // FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
      // FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
      // FirstClassPassenger _ => 2000M,

      //C# 9 or later syntax
      // FirstClassPassenger p => p.AirMiles switch{
      //    > 35000 => 1500M,
      //    > 15000 => 1750M,
      //    _       => 2000M
      // },

      FirstClassPassenger {AirMiles: > 35000} => 1500,
      FirstClassPassenger {AirMiles: > 15000} => 1750M,
      FirstClassPassenger                     => 1750M,

      BusinessClassPassenger _ => 1000M,
      CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
      CoachClassPassenger _ => 650M,
      _ => 800M
   };
   WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

ImmutablePerson jeff = new()
{
   FirstName = "Jeff",
   LastName = "Winger"
};

// jeff.FirstName = "Geoff";
// WriteLine("Jeff: " + jeff.FirstName);