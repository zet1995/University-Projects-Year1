# Summative 1

## Challenge Description

This time you're going to calculate the cost to hire a car. When a customer hires the car is has a full tank of petrol. The tank holds 50 litres of fuel.

The car hire cost is £25 per day hired, plus £2.50 per litre of petrol used and a £10 booking fee.

Your program should ask the user how many days the car was hired for, then how many litres of fuel were left in the tank when it was returned.

## Code Listing

```cs
// Include your C# solution code here
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Car Hire Calculator");
const double bookingFee = 10;
const double pricePerDay = 25;
const double startingFuel = 50;
const double fuelPrice = 2.50;
Console.Write("How many days was the car hired for? ");
string daysInput = Console.ReadLine();
double days = double.Parse(daysInput);
Console.Write("How much fuel was left in the tank?");
string fuelLeftInput = Console.ReadLine();
double fuelLeft = double.Parse(fuelLeftInput);                                                                                
double result = (double)(bookingFee + days * pricePerDay + (startingFuel - fuelLeft) * fuelPrice);
Console.WriteLine("The total charge for the car hire is: £" + result);
                             
```

## Test Plan

Include your test plan and results here

| Test Number | Input | Expected Output | Actual Output |
|---|---|---|---|
| 1 |"0","50" |"The total charge for the car hire is: £10" |"The total charge for the car hire is: £10" |
| 2 |"1","50" |"The total charge for the car hire is: £35" |"The total charge for the car hire is: £35" |
| 3 |"0","49" |"The total charge for the car hire is: £12.5" |"The total charge for the car hire is: £12.5" |
| 4 |"1","30" |"The total charge for the car hire is: £85" |"The total charge for the car hire is: £85" |
| 5 |"3","50" |"The total charge for the car hire is: £85" |"The total charge for the car hire is: £85" |
| 6 |"2","15" |"The total charge for the car hire is: £147.5" |"The total charge for the car hire is: £147.5" |
| 7 |"5","20" |"The total charge for the car hire is: £210" |"The total charge for the car hire is: £210" |
| 8 |"cheeseburger" |Program crashes |Program crashes |
## Feedback Request

If there is anything specific you want to ask for feedback on include that here
