using _3.Raiding.Models;

int n = int.Parse(Console.ReadLine());
List<BaseHero> heroes= new List<BaseHero>();
for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    string race= Console.ReadLine();
    switch (race)
    {
        case "Druid":
            Druid druid = new Druid(name, 80);
            heroes.Add(druid);
            break;
        case "Paladin":
            Paladin paladin = new Paladin(name, 100);
            heroes.Add(paladin);
            break;
        case "Rogue":
            Rogue rogue = new Rogue(name, 80);
            heroes.Add(rogue);
            break;
        case "Warrior":
            Warrior warrior = new Warrior(name, 100);
            heroes.Add(warrior);
            break;
        default:
            Console.WriteLine("Invalid hero!");
            i--;
            break;
    }
}
int bossPower = int.Parse(Console.ReadLine());
int grouPower = 0;
foreach (var item in heroes)
{
    Console.WriteLine(item.CastAbility());
    grouPower += item.Power;
}
if (grouPower>=bossPower)
{
    Console.WriteLine("Victory!");
}
else
{
    Console.WriteLine("Defeat...");
}