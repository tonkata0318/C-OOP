using WildFarm.Models;

string command = string.Empty;
while ((command=Console.ReadLine())!="End")
{
    string[] animal = command.Split(" ");
    string animalType = animal[0];
    string[] food = Console.ReadLine().Split(" ");
    string foodType = food[0];
    switch (animalType)
    {
        case "Hens":
            Hen hens = new Hen(animal[1], double.Parse(animal[2]), int.Parse(animal[3]), double.Parse(animal[4]));
            hens.Sound();
            hens.IncreaseWeight(0.35);
            break;
        case "Mouse":
            Mouse mouse = new Mouse(animal[1], double.Parse(animal[2]), int.Parse(animal[3]), animal[4]);
            mouse.Sound();
            switch (foodType)
            {
                case "Vegetable":
                    mouse.IncreaseWeight(0.10);
                    break;
                case "Fruits":
                    mouse.IncreaseWeight(0.10);
                    break;
                default:
                    Console.WriteLine($"Mouse does not eat {foodType}!");
                    break;
            }
            break;
        case "Cats":
            Cat cat = new Cat(animal[1], double.Parse(animal[2]), int.Parse(animal[3]), animal[4]);
            cat.Sound();

            break;
        case "Tiger":
            Tiger tiger = new Tiger(animal[1], double.Parse(animal[2]), int.Parse(animal[3]), animal[4]);
            tiger.Sound();
            break;
        case "Dog":
            Dog dog = new Dog(animal[1], double.Parse(animal[2]), int.Parse(animal[3]), animal[4]);
            dog.Sound();
            break;
        case "Owls":
            Owl owl = new Owl(animal[1], double.Parse(animal[2]), int.Parse(animal[3]), double.Parse(animal[4]));
            owl.Sound();
            break;
        default:
            break;
    }
}