namespace Ch06Ex02Inheritance
{
    public class Rectangle : Shape
    {

        public Rectangle(float h, float w)
        {
            Height = h;
            Width = w;
            Area = h * w;
        }       
    }
}