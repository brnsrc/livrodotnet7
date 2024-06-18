using System.Xml.Linq; //XDocument
using System;

XDocument doc = new();

string s1 = "Hello";
String s2 = "World";

WriteLine($"{s1} {s2}");

WriteLine($"int.MaxValue = {int.MaxValue:N0}");
WriteLine($"nint.MaxValue = {nint.MaxValue:N0}");