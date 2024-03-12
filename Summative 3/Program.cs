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
