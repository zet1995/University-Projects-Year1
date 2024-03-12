// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Summative 6!");
using Summative_6;

class program
{
    static void Main()
    {
        Console.WriteLine("Hello, Summative 6!");

        Circle circle = new Circle(-2);
        Console.WriteLine(circle.GetRadius());
        Console.WriteLine(circle.GetCircumference());
        Console.WriteLine(circle.GetArea());
        Console.WriteLine(circle.GetID());

        Circle circle2 = new Circle(8);
        Console.WriteLine(circle2.GetRadius());
        Console.WriteLine(circle2.GetCircumference());
        Console.WriteLine(circle2.GetArea());
        Console.WriteLine(circle2.GetID());

        circle2.SetRadius(4);
        Console.WriteLine(circle2.GetRadius());
        Console.WriteLine(circle2.GetCircumference());
        Console.WriteLine(circle2.GetArea());
        Console.WriteLine(circle2.GetID());



    }

}
