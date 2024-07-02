string city = "London";
WriteLine($"{city} is {city.Length} characters long.");

WriteLine($"First char is {city[0]} and fourth is {city[3]}.");

string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array: ");

foreach (string item in citiesArray)
{
    WriteLine(item);
}

string fullName = "Alan Shore";
int indexOfTheSpace = fullName.IndexOf(' ');
string firstname = fullName.Substring(startIndex: 0, length: indexOfTheSpace);
string lastName = fullName.Substring(startIndex: indexOfTheSpace + 1);
WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstname}");


//Exercicio
string name = "Shore, Alan";
string[] arrayName = name.Split(',');
WriteLine($"Exercicio Entrada: {name}");
WriteLine($"Exercicio Troca: {arrayName[1]} {arrayName[0]}");

string company = "Microsoft";
bool startWithM = company.StartsWith("M");
bool containsN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startWithM}, contains an N: {containsN}");

string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string fruit = "Apple";
decimal price = 0.39M;

DateTime when = DateTime.Today;
WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}.");
WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}.", 
arg0: fruit, arg1: price, arg2: when));