using SingletonDemo;
var db=new SingletondataContainer().Instance;
Console.WriteLine(db.GetPopulation("Washington, D.C."));
Console.WriteLine(db.GetPopulation("London"));