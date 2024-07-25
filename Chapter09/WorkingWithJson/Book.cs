using System.Text.Json; //JSON serializer
using System.Text.Json.Serialization;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithJson
{
    public class Book
    {        
        //constructor to set non-nullable property
        public Book(string title)
        {
            Title = title;
        }       
        //properties
        public string Title { get; set;}
        public string? Author { get; set;}
        //fields
        [JsonInclude] //include this field
        public DateTime PublishDate;

        [JsonInclude] //include this field
        public DateTimeOffset Created;
        public ushort Pages;        
    }
}