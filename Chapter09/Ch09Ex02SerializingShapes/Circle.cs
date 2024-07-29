using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Ch09Ex02SerializingShapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle()
        {
            Area = 3.14 * (this.Radius*this.Radius);                   
        }
    }
}