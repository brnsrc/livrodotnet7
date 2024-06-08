namespace Ch06Ex02Inheritance
{
    public class Square : Shape
    {
        public Square(float valor)
        {
            this.Width = valor;
            this.Height = valor;

            this.Area = this.Height * this.Width;
        }
        
    }
}