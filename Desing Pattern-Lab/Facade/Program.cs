using Facade;

var car = new CarBuilderFacade()
    .Info
    .WithType("BMW")
    .WithColor("Black")
    .WithNumberOfDoors(5)
    .Built
    .InCity("Leipzig")
    .AtAddress("Some adress 254")
    .Build();
Console.WriteLine(car);


