using _1.Vehicles.Models;

string[] car1 = Console.ReadLine().Split(" ");
Car car = new Car(double.Parse(car1[1]), double.Parse(car1[2]), int.Parse(car1[3]));
string[] truck1 = Console.ReadLine().Split(" ");
Truck truck = new Truck(double.Parse(truck1[1]), double.Parse(truck1[2]), int.Parse(truck1[3]));
string[] bus1 = Console.ReadLine().Split(" ");
Bus bus = new Bus(double.Parse(bus1[1]), double.Parse(bus1[2]), int.Parse(bus1[3]));
int n=int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] cmdInfo = Console.ReadLine().Split(" ");
    string venchile = cmdInfo[1];
    if (venchile=="Car")
    {
        if (cmdInfo[0]=="Drive")
        {
            car.Drive(double.Parse(cmdInfo[2]));
        }
        else
        {
            car.Refuel(double.Parse(cmdInfo[2]));
        }
    }
    else if (venchile=="Truck")
    {
        if (cmdInfo[0] == "Drive")
        {
            truck.Drive(double.Parse(cmdInfo[2]));
        }
        else
        {
            truck.Refuel(double.Parse(cmdInfo[2]));
        }
    }
    else if (venchile=="Bus")
    {
        if (cmdInfo[0] == "DriveEmpty")
        {
            bus.DriveEmpty(double.Parse(cmdInfo[2]));
        }
        else if (cmdInfo[0]=="Drive")
        {
            bus.Drive(double.Parse(cmdInfo[2]));
        }
        else
        {
            bus.Refuel(double.Parse(cmdInfo[2]));
        }
    }
}
Console.WriteLine($"Car: {car.fuelquantity:f2}");
Console.WriteLine($"Truck: {truck.fuelquantity:f2}");
Console.WriteLine($"Bus: {bus.fuelquantity:f2}");