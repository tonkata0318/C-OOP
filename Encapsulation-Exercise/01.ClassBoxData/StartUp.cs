namespace _01.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double lentgh = double.Parse(Console.ReadLine());
            double width=double.Parse(Console.ReadLine());
            double height=double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(lentgh, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}