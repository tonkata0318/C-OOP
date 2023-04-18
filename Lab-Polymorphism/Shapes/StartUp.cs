namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2.5, 5);
            Circle circle = new Circle(5);
            Console.WriteLine(rectangle.CalculatePerimeter()) ;
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
        }
    }
}