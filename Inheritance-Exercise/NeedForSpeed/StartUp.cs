namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(100, 50);
            sportCar.Drive(5);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(40, 150);
            raceMotorcycle.Drive(5);
        }
    }
}
