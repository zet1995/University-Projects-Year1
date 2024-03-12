# Summative 2

## Challenge Description
Problem Specification
There are three elements of assessment in the programming portfolio module. They are the Digital Portfolio, the Open Book Programming Exam and the Capstone Project.

Each assessment is awarded a different number of marks, and each assessment has a different weighting. These are shown in the table below.

| Element of Assessment |	Weighting |	Marked out of |	Compulsory Element of Assessment |
|---|---|---|---|
| Digital Portfolio |	50% |	35 | No |
|Open Book Programming Exam|	25%|	7|	Yes - You must pass this to pass the module|
|Capstone Project|	25%	|100	|Yes - You must pass this to pass the module|

Additionally, both the Open Book Programming Exam and the Capstone Project are compulsory elements of assessment. If student's do not pass a compulsory element or assessment the entire module mark is capped at 34%.

If you do not pass a module the you will be offered reassessments in the elements of assessment that you failed. If you do not pass the reassessments and as a result fail a core module you cannot progress to the next stage of your degree. Instead you must either apply to repeat the entire year, or withdraw from your studies and be awarded credits for the modules you have passed.

Students who successfully complete an Honours degree are awarded a degree with a certain classification which is calculated from the weighted mark for your overall degree, These degree classifications are also often used to describe a students performance in an individual module. The highest classification is First-Class Honours (First or 1st) which is awarded for marks of 70% and above. The Upper Second-Class Honours (2:1, 2.i) is awarded for marks of 60-70%. The Lower Second-Class Honours (2:2, 2.ii) is awarded for marks of 50-60%. The lowest Honours degree is the third class degree (Third or 3rd) which is awarded for marks of 40-50% All mark ranges are inclusive of their lower bounds, and exclusive of their upper bounds.

Your challenge is to write a program that requests a student's raw marks for the three elements of assessment of the Programming Portfolio module, and calculates the outcome of the module. Raw marks can only be entered as whole numbers. To do this you should first convert the mark from a raw mark into a percentage. A percentage mark can be calculated by dividing the marks awarded by the total available marks, and multiplying by 100. For example the Digital Portfolio is marked out of 35, if a student scored 30 marks their percentage mark would be 100 * 30 / 35 = 85% (to 2 decimal places).

Once you have all three marks expressed as percentages you can calculate the overall classification by multiplying each mark by it's weighting divided by 100, and then adding the three outcomes together. So for example if a student was awarded 80% for the digital portfolio, 60% for the open book programming exam and 65% for the capstone project their overall module mark would be (80 * 50 / 100) + (60 * 25 / 100) + (65 * 25 / 100) = 40 + 15 + 16.25 = 71%

Once you have the overall module mark you can use that to determine the module outcome. The various module outcomes are described in the test data below. Remember, if a student does not achieve a passing mark of 40% or higher in a compulsory element of assessment the entire module mark is capped at 34%. 

Marks should be accurate to 2 decimal places. To help you do that you can use the following code:

|moduleMark = (float)Math.Round(moduleMark, 2);|
|---|


## Code Listing

```cs
// Include your C# solution code here
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

## Test Plan

Include your test plan and results here

| Test Number | Digital Portfolio Mark| Open Book Programming Exam Mark| Capstone Project Mark | Expected Output | Actual Output |
|---|---|---|---|---|---|
| 1 |-1 | | |-1 is not a valid mark for the digital portfolio |-1 is not a valid mark for the digital portfolio |
| 2 |36 | | |36 is not a valid mark for the digital portfolio |36 is not a valid mark for the digital portfolio |
| 3 |25.5 | | |	program crashes |	program crashes |
| 4 |35 |-1 | |	-1 is not a valid mark for the open book programming exam |	-1 is not a valid mark for the open book programming exam |
| 5 |35 |8 | |	8 is not a valid mark for the open book programming exam |	8 is not a valid mark for the open book programming exam |
| 6 |35 |5.5 | |	program crashes |	program crashes |
| 7 |35 |7 |-1 |	-1 is not a valid mark for the capstone project |	-1 is not a valid mark for the capstone project |
| 8 |35 |7 |101 |	101 is not a valid mark for the capstone projec |	101 is not a valid mark for the capstone projec |
| 9 |35 |7 |65.5 |	program crashes |	program crashes |
| 10 |35 |7 |100 |	100% - 1st |	100% - 1st |
| 11 |25 |5 |70 |	71.07% - 1st |	71.07% - 1st |
| 12 |26 |4 |69 |	68.68% - 2:1 |	68.68% - 2:1 |
| 13 |22 |4 |60 |	60.71% - 2:1 |	60.71% - 2:1 |
| 14 |21 |4 |60 |	59.29% - 2:2 |	59.29% - 2:2 |
| 15 |17 |4 |50 |	51.07% - 2:2 |	51.07% - 2:2 |
| 16 |16 |4 |50 |	49.64% - 3rd |	49.64% - 3rd |
| 17 |14 |3 |40 |	40.71% - 3rd |	40.71% - 3rd |
| 18 |13 |3 |40 |	39.29% - fail |	39.29% - fail |
| 19 |10 |3 |40 |	35% - fail |	35% - fail |
| 20 |35 |2 |100 |	34% - fail |	34% - fail |
| 21 |35 |7 |39 |	34% - fail |	34% - fail |
| 22 |12 |2 |33 |	32.54% - fail |	32.54% - fail |
| 23 |0 |0 |0 |	0% - fail |	0% - fail |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
