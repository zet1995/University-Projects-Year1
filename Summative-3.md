# Summative 3

## Challenge Description

Summative Challenge 3 - Oyster Eating Competition (Due on or before 17th November)
Goal
The goal of this challenge is to demonstrate the following things:

Loops
Arrays
Output to a file
More advanced techniques are not required, but you may include them if you wish.

Setting Up Your Project
For this summative challenge you should use your digital portfolio repository. You should complete this work in your Digital Portfolio Repository in GitHub.

If you have not already accepted this assignment in GitHub classroom you can do so by clicking this link: https://classroom.github.com/a/JN1fvSJNLinks to an external site.

Problem Specification
"At the New Orleans Oyster Festival, eight eaters will slurp down as many mollusks as they can in the allotted eight minutes. The winner takes home $1,000 from Major League Eating (MLE), which also oversees the ESPN-televised Nathan’s Famous hot dog eating contest on Coney Island every summer." (The world of competitive oyster eating: 'your stomach is like a human Tetris' | Food | The GuardianLinks to an external site.)

You are tasked with writing a program that allows you to enter the number of competitors in the competition, the name of each competitor, and the number of oysters each competitor ate. Once all the competitors are entered you should sort them with respect to the number of oysters eaten (write your own sorting algorithm - do not use the built in sort), output them to the Console and save the results to a file called results.txt.

The output should look something like this:

image.png

You should also write them to a file called "results.txt".

image.png

Tips

Split the problem into stages
Store scores in one array and names in another array (each of the appropriate type)
Write a bubble sort to sort the scores array - at the same time update the names array so that they stay in sync
Write the sorted arrays to the Console
Write the sorted arrays to a file

## Code Listing

```cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Oyster Eating Competition");
Console.WriteLine("How many competitors are there?");
int competitorsNumber = int.Parse(Console.ReadLine());

int[]numberOfOysters = new int[competitorsNumber];
string[]competitorsName = new string[competitorsNumber];

for (int i = 0; i < competitorsNumber; i++)
{
    Console.WriteLine("What is competitor number "+(i+1)+"'s name?" );
    competitorsName[i] =(Console.ReadLine());
    Console.WriteLine("How many oysters did " + competitorsName[i] +" eat?");
    numberOfOysters[i] = int.Parse(Console.ReadLine());
}
int tempNumber = 0;
string tempName;
for(int i=0; i<numberOfOysters.Length; i++)
{
    for(int j=0;  j<numberOfOysters.Length-1; j++)
    {
        if (numberOfOysters[j] < numberOfOysters[j + 1])
        {
            tempNumber = numberOfOysters[j+1];
            numberOfOysters[j + 1] = numberOfOysters[j];
            numberOfOysters[j] = tempNumber;
            tempName = competitorsName[j + 1];
            competitorsName[j + 1] = competitorsName[j];
            competitorsName[j]= tempName;
        }
    }
}
for(int i = 0;i < numberOfOysters.Length; i++)
{
    Console.WriteLine((i+1)+". "+ competitorsName[i] + " ate " + numberOfOysters[i] + " oysters" );
}
using (StreamWriter writetext = new StreamWriter("results.txt"))
{
    for (int i = 0; i < numberOfOysters.Length; i++)
    {
        writetext.WriteLine((i + 1) + ". " + competitorsName[i] + " ate " + numberOfOysters[i] + " oysters");
    }
}
```

## Test Plan

Include your test plan and results here

| Test Number | Input | Expected Output | Actual Output |
|---|---|---|---|
| 1 |5    Simon Grey 232    David Parker 286    John Dixon 212    Adrian Morgan 432    Sonya Thomas 492 |1. Sonya Thomas ate 492 oysters    2. Adrian Morgan ate 432 oysters    3. David Parker ate 286 oysters    4. Simon Grey ate 232 oysters    5. John Dixon ate 212 oysters |1. Sonya Thomas ate 492 oysters    2. Adrian Morgan ate 432 oysters    3. David Parker ate 286 oysters    4. Simon Grey ate 232 oysters    5. John Dixon ate 212 oysters |
| 2 |3    Michelle Lesco 324    Darron Breeden 480    Adrian Morgan 312 |1. Darron Breeden ate 480 oysters    2. Michelle Lesco ate 324 oysters    3. Adrian Morgan ate 312 oysters |1. Darron Breeden ate 480 oysters    2. Michelle Lesco ate 324 oysters    3. Adrian Morgan ate 312 oysters |
| 3 |8    Lily Anderson 47    Ethan Miller 53    Olivia Smith 39    Jackson White 61    Sophia Lee 45    Noah Johnson 50    Ava Brown 55    Mason Harris 48 |1. Jackson White ate 61 oysters    2. Ava Brown ate 55 oysters    3. Ethan Miller ate 53 oysters    4. Noah Johnson ate 50 oysters    5. Mason Harris ate 48 oysters    6. Lily Anderson ate 47 oysters    7. Sophia Lee ate 45 oysters    8. Olivia Smith ate 39 oysters |1. Jackson White ate 61 oysters    2. Ava Brown ate 55 oysters    3. Ethan Miller ate 53 oysters    4. Noah Johnson ate 50 oysters    5. Mason Harris ate 48 oysters    6. Lily Anderson ate 47 oysters    7. Sophia Lee ate 45 oysters    8. Olivia Smith ate 39 oysters |


## Feedback Request

If there is anything specific you want to ask for feedback on include that here
