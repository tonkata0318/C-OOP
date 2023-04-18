namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Magician", 5);
            System.Console.WriteLine(wizard.ToString());
        }
    }
}