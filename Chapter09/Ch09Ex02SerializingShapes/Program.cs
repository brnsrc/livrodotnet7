//create a list of shapes to serialize
using Ch09Ex02SerializingShapes;
using System.Xml.Serialization;
using System.IO;
using static System.Environment;

//cria um arquivo
string caminho = Path.Combine(CurrentDirectory, "listOfShapes.xml");

//Criando uma lista
List<Shape> listOfShapes = new(){
    new Circle{Colour = "Red", Radius = 2.5},
    new Rectangle{Colour = "Blue", Height = 20.0, Width= 10.0},
    new Circle{Colour = "Green", Radius=8.0},
    new Circle{Colour = "Purple", Radius=12.3},
    new Rectangle{ Colour = "Blue", Height = 45.0, Width = 18.0}
};

// Circle circle = new Circle { Colour = "Red", Radius = 2.5 };
// System.Console.WriteLine($"Raio: {circle.Colour} - Área: {circle.Area}");

//criando um objeto q ira formatar de uma lista de Shapes para um formato XML
XmlSerializer xmlSerializer = new(type: listOfShapes.GetType());

using (FileStream stream = File.Create(caminho))
{
    //serializa o objeto para um arquivo
    xmlSerializer.Serialize(stream, listOfShapes);
}

System.Console.WriteLine("Arquivo Xml criado");
Console.ReadKey();

using (FileStream carregaXml = File.Open(caminho, FileMode.Open))
{
    //deserializa e converte o objeto de uma lista
    List<Shape>? loadListOfShapesXml = xmlSerializer.Deserialize(carregaXml) as List<Shape>;
    System.Console.WriteLine("Loading shapes from XML:");
    if (loadListOfShapesXml is not null)
    {
        foreach (Shape item in loadListOfShapesXml)
        {
            System.Console.WriteLine(
                $"{item.GetType().Name} is {item.Colour} and has an area of {item.Area:N2}");
        }
    }
}

