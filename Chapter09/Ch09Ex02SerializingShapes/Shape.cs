using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Ch09Ex02SerializingShapes
{
    public abstract class Shape
    {
        public string Colour { get; set; }
        internal double Area;

    }
}