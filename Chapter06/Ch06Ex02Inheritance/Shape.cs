using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch06Ex02Inheritance
{
    public abstract class Shape
    {
        public string? Colour{ get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Area { get; set; }

    }
}