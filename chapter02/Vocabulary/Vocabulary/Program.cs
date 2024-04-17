namespace Vocabulary {
    using System.IO.Pipes;
    using System.Reflection;
    internal class Program {
        static void Main(string[] args) {
            string xml = """
                <person age="50">
                    <first_name>Mark</first_name>
                </person>
                """;

            string json = $$"""
                {
                    "first_name":"{{person.FirstName}}",
                    "age":{{person.age}},
                };
                """

            Console.WriteLine("Hello, World!");

        }
    }
}
