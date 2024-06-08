namespace Ch06Ex02Inheritance
{
    public class Circle : Shape
    {
        public float Radius { get; set; }
        private readonly float pi = 3.14f;
        public Circle(float r)
        {
            Radius = r;
            Area = pi * (Radius * Radius);
            Width = 2 * Radius;
            Height = 2 * Radius;
        }        
    }
}