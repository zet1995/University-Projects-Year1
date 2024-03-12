// See https://aka.ms/new-console-template for more information
Console.WriteLine("Programming Portfolio Results Calculator ");

const float digitalPortofolioWeighting = 50f;
const float openBookWeighting = 25f;
const float capstoneWeighting = 25f;

Console.WriteLine("What was the Digital Portofolio mark?(out of 35) ");
int portofolioMark = int.Parse(Console.ReadLine());
while (portofolioMark < 0 || portofolioMark > 35)
{
    Console.WriteLine(portofolioMark + " is not a valid mark for the Digital Portfolio");
    Console.WriteLine("What was the Digital Portofolio mark?(out of 35) ");
    portofolioMark = int.Parse(Console.ReadLine());
}
float portofolioMarkPercent = 100f * (float)portofolioMark / 35f;
portofolioMarkPercent = (float)Math.Round(portofolioMarkPercent, 2);

Console.WriteLine("What was the Open Book Programming Exam mark? (out of 7) ");
int examMark = int.Parse(Console.ReadLine());
while (examMark < 0 || examMark > 7)
{
    Console.WriteLine(examMark + " is not a valid mark for the Open Book Programming Exam");
    Console.WriteLine("What was the Open Book Programming Exam mark? (out of 7) ");
    examMark = int.Parse(Console.ReadLine());
}
float examMarkPercent = 100f * (float)examMark / 7f;
examMarkPercent = (float)Math.Round(examMarkPercent, 2);

Console.WriteLine("What was the Capstone Project mark? (out of 100) ");
int projectMark = int.Parse(Console.ReadLine());
while(projectMark < 0 || projectMark > 100)
{
    Console.WriteLine(projectMark + " is not a valid mark for the Capstone Project");
    Console.WriteLine("What was the Capstone Project mark? (out of 100) ");
    projectMark = int.Parse(Console.ReadLine());
}
float projectMarkPercent = (float)Math.Round((float)projectMark, 2);

float moduleMark = (portofolioMarkPercent * digitalPortofolioWeighting / 100) + (examMarkPercent * openBookWeighting / 100) + (projectMarkPercent * capstoneWeighting / 100);
moduleMark = (float)Math.Round(moduleMark, 2);
if(moduleMark >34 && (examMarkPercent < 40 || projectMarkPercent < 40))
{
    moduleMark = 34;
}

if (moduleMark >= 70)
{
    Console.WriteLine(moduleMark + "% - 1st");
}
else if(moduleMark >= 60 && moduleMark < 70)
{
    Console.WriteLine(moduleMark + "% - 2:1");
}
else if(moduleMark >= 50 && moduleMark < 60)
{
    Console.WriteLine(moduleMark + "% - 2:2");
}
else if(moduleMark >= 40 && moduleMark < 50)
{
    Console.WriteLine(moduleMark + "% - 3rd");
}
else
{
    Console.WriteLine(moduleMark + "% - fail");
}
Console.ReadLine();
