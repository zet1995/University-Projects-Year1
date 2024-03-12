// See https://aka.ms/new-console-template for more information

Console.WriteLine("Car Hire Calculator");
const double bookingFee = 10;
const double pricePerDay = 25;
const double startingFuel = 50;
const double fuelPrice = 2.50;

Console.Write("How many days was the car hired for? ");
double days = double.Parse(Console.ReadLine());
Console.Write("How much fuel was left in the tank?");
double fuelLeft = double.Parse(Console.ReadLine());

double rentPrice=days * pricePerDay;
double totalFuelPrice = (startingFuel - fuelLeft) * fuelPrice;
double result = (double)(bookingFee + rentPrice + totalFuelPrice);

Console.WriteLine("The total charge for the car hire is: £" + result);
