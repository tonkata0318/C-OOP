namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Lizard lizard = new Lizard("Pesho");
            System.Console.WriteLine(lizard.Name);
        }
    }
}