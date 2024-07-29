//create a list of shapes to serialize
using Ch09Ex02SerializingShapes;

// List <Shape> listOfShapes = new(){
//     new Circle{Colour = "Red", Radius = 2.5},
//     new Rectangle{Colour = "Blue", Height = 20.0, Width= 10.0},
//     new Circle{Colour = "Green", Radius=8.0},
//     new Circle{Colour = "Purple", Radius=12.3},
//     new Rectangle{ Colour = "Blue", Height = 45.0, Width = 18.0}
// };


Circle circle = new Circle{Colour = "Red", Radius = 2.5};
System.Console.WriteLine($"Raio: {circle.Colour} - Área: {circle.Area}");
System.Console.WriteLine($"Raio: {circle.Colour} - Área: {3.14 * (circle.Radius * circle.Radius)}");
