List<string> cities = new();
cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

//Alternative syntax that is converted by the compiler into the three Add methd calls above.
// List<string> cities = new(){"London", "Paris", "Milan"};

//Alternative syntax that passes an arrayn of string values to AddRange method
// List<string> cities2 = new();
// cities2.AddRange(new[] { "London", "Paris", "Milan" });

Output("Initial list", cities);

WriteLine($"The first city is {cities[0]}");
WriteLine($"The last city is {cities[cities.Count - 1]}.");
cities.Insert(0, "Sydney");

Output("After inserting Sydney at index 0", cities);
cities.RemoveAt(1);
cities.Remove("Milan");

Output("After removing two cities", cities);


Dictionary<string, string> keywords = new();
//add using named parameters
keywords.Add(key: "int", value: "32-bit integer data type");

//add using positional parameters
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

//Alternative syntax; compiler converts this to calls to Add method
// Dictionary<string, string> keywords2 = new(){
//     {"int", "32-bit integer data type"},
//     {"long", "64-bit integer data type"},
//     {"float", "Single precision floating point number"}
// };

// Dictionary<string, string> keywords2 = new()
// {
//     ["int"] = "32-bit integer data type",
//     ["long"] = "64-bit integer data type",
//     ["float"] = "Single precision floating point number", //last comma is optional
// };

Output("Dictionary keys: ", keywords.Keys);
Output("Dictionary keys: ", keywords.Values);

WriteLine("Keywords and their definitions");
foreach (KeyValuePair<string, string> item in keywords)
{
    WriteLine($"{item.Key}: {item.Value}");
}

//look up value using a key
string key = "long";
WriteLine($"the definition fo {key} is {keywords[key]}");