using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ch09Ex02SerializingShapes
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Shape
    {
        public string? Colour { get; set; }
        public abstract double Area { get; }
        public Shape() { }

    }
}