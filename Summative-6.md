# Summative 6

## Challenge Description

Include a decription of the challenge here.
Summative Challenge 6 - Objects & Encapsulation (Due on or before 23rd February)
In your digital portfolio repository open the summative 6 project. Note some of the aspects of this exercise will be covered in the upcoming week's labs.

Add a Circle class to the project. Add functionality to the Circle class to achieve the following:

Create a circle by passing a radius.
Create a circle without passing a radius - assigning a value of 1 to the radius (hint - use constructor chaining).
Add a member method that calculates the Area of the Circle.
Add a member method that calculates the Circumference of the Circle.
Give each instance of a Circle a unique ID number.
Add functionality to allow the user to change the Radius of the Circle.
Ensure that the Radius of the Circle CAN NEVER be negative.
Write some code to test you are able to create circles, find their area and circumference, change the radius, and ensure the area and circumference are still correct with the new radius.
The below UML class diagram should give you a hint. If you want to know more about generating UML class diagrams see https://mermaid.js.org/Links to an external site.

Note that UML is a Unified Modelling Language which means that it is language agnostic. Sometimes there isn't an established way to represent some features of a specific language (like C# properties). 

Mermaid.js is a really useful tool that you can use to create, edit and display class diagrams in GitHub markdown - which is really useful when documenting your code on GitHub.

image.png
Commit and Push Your Changes
Once you are happy with your work commit and push your changes to your digital portfolio github repository.

## Code Listing

```cs
// Include your C# solution code here
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_6
{
    internal class Circle
    {
        private float radius;
        private int ID;
        private static int NextID=1;


        public Circle() : this(1) {}

        public Circle(float radius)
        {
            this.SetRadius(radius);
            this.ID = NextID;
            NextID++;
        }

        public float GetArea()
        {
            float Area = (float)Math.PI * (radius * radius);
            //Console.WriteLine(Area);
            return (float)Area;
        }
        public float GetCircumference()
        {
            float Circumference= 2*((float)Math.PI) * radius;
            return Circumference;
        }
        public int GetID()
        {
            return ID;
        }
        public float GetRadius()
        {
            return this.radius;
        }
        public bool SetRadius(float radius)
        {
            if (radius > 0)
            {
                this.radius=radius;
                return true;
            }
            else
            {
                Console.WriteLine("Can't have a circle with a negative radius");
                return false;
            }
            
        }
    }

}

```

## Test Plan

Include your test plan and results here

| Test Number | Input | Expected Output | Actual Output |
|---|---|---|---|
| 1 | | | |
| 2 | | | |
| 3 | | | |
| 4 | | | |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
