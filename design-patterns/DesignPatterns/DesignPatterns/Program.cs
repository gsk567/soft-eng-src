
using DesignPatterns;
using DesignPatterns.Facade;

// var kebapFactory = new KebapFactory();
//
// var user = new User { Name = "Pesho" };
// UserProvider.Instance.SaveUser(user);
//
// var kebapRequestBuilder = new KebapRequestBuilder();
//
// kebapRequestBuilder
//     .Spicy()
//     .WithVegitables(false);
//
// var kebap = kebapFactory.CreateKebap(kebapRequestBuilder.Build());
//
// Console.WriteLine(kebap);

var playstationController = new PlaystationController();

playstationController.Up();
playstationController.Down();
playstationController.Left();
playstationController.Right();

Console.ReadKey();