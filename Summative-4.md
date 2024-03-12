# Summative 4
## Challenge Description

Summative Challenge 4 - Programming Portfolio Results Calculator Revisited (Due on or before 1st December)
Goals
Use methods to breakdown a large problem into smaller parts, reduce scope and improve readability
Read input from a file
Setting Up Your Project
For this summative challenge you should use your digital portfolio repository. You should complete this work in your Digital Portfolio Repository in GitHub.

If you have not already accepted this assignment in GitHub classroom you can do so by clicking this link: https://classroom.github.com/a/JN1fvSJNLinks to an external site.

Problem Specification
You have been provided with data files containing the marks of students on the Programming Portfolio module.

Your task is to do the following.

Ask the user to select a file from a list of available files with the .mark extension from the current directory
Load the data from the file
Calculate the overall module marks for each student according to the rules described in 📒Summative Challenge 2
Note that in this case there are a total of 9 digital portfolio marks - one for each challenge.
To account for unexpected absence we award the best 4 challenge marks of the first 5 challenges, and the best 3 challenge marks of the last 4 challenges to generate a mark out of 35 from 7 challenges
Count the number of students with 1st class, 2:1, 2:2 and 3rd class results and output this to the console
Sort the students by overall module mark
Output the sorted results to another file in the specified format
You should pay special attention to your use of methods to breakdown a large problem into smaller parts, reduce scope and improve readability.

Input
Each line of the file contains data about a single student. The data is in the following format.

Student:[ID:2022232445,LastName:Grey,FirstName:Simon],Marks:[Challenges:[2, 3, 4, 5, 3, 2, 4, 5, 5],Exam:7,Capstone:85]
Console Output
The console output should look something like this - in this case the 11th file - 326Students.mark was selected:

image.png

File Output
The output file should have the same filename as the input file, but the .mark extension should be removed, and the output file should end with "Output.txt"

Each line in the file should include one student. The file output should be in the format Mark - FirstName LastName (ID)

Lines should be sorted in descending mark order. The output file for the "5StudentsOneEachClassification.mark" file should be called "5StudentsOneEachClassificationOutput.txt" and should look like this;

image.png

Test Data
The test data has been designed to help you test specific aspects of your program. You can download all the test files together from this link TestInputFiles.zipDownload TestInputFiles.zip

Working with Files
There is some advice about working with files in Visual Studio at Working with Files in Visual Studio

## Code Listing

```cs
// See https://aka.ms/new-console-template for more information
using System.Runtime.ExceptionServices;
namespace Nume
{
    class Program
    {
        const float digitalPortofolioWeighting = 50f;
        const float openBookWeighting = 25f;
        const float capstoneWeighting = 25f;
        static int first = 0;
        static int secondFirst = 0;
        static int secondSecond = 0;
        static int third = 0;
        static int fail = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Please select a file to load.");

            string[] files = LoadAndDisplayFiles();

            int userInput = int.Parse(Console.ReadLine());

            string[] data = File.ReadAllLines(files[userInput - 1]);

            string [][] output = new string[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {

                string[] words = data[i].Split(':', ',', '[', ']');
                int moduleMark = CalculateMark(words);
                moduleMark= ClassifyStudents(moduleMark,words);
                output[i] = new string[2];
                output[i][0] = moduleMark.ToString();
                output[i][1] = " - " + words[7] + " " + words[5] + " (" + words[3] + ")";
            }
            output = SortOutput(output);

            string fileOutput = Path.GetFileNameWithoutExtension(files[userInput - 1]) + "Output.txt";
            WriteToFile(output, fileOutput);

            Console.WriteLine(first + " First");
            Console.WriteLine(secondFirst + " 2:1");
            Console.WriteLine(secondSecond + " 2:2");
            Console.WriteLine(third + " Third");
            Console.WriteLine(fail + " Fail");
        }

        public static string[] LoadAndDisplayFiles()
        {
            string[] files = Directory.GetFiles("C:\\Users\\cozmi\\source\\repos\\University-of-Hull-CST\\441101-2324-digital-portfolio-zet1995\\Summative 4\\bin\\Debug\\net6.0\\files");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + Path.GetFileName(files[i]));
            }
            return files;
        }

        public static string[][] SortOutput(string[][] output)
        {
            string[] tempNumber = new string[2];
            for (int i = 0; i < output.Length; i++)
            {
                for (int j = 0; j < output.Length - 1; j++)
                {
                    if (int.Parse(output[j][0]) < int.Parse(output[j + 1][0]))
                    {
                        tempNumber = output[j];
                        output[j] = output[j + 1];
                        output[j + 1] = tempNumber;
                    }
                }
            }
            return output;
        }

        public static void WriteToFile(string[][] output, string fileName)
        {
            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                for (int i = 0; i < output.Length; i++)
                {
                    writetext.WriteLine(output[i][0] + output[i][1]);
                }
            }
        }

        public static int CalculateMark(string[] words)
        {
            int[] first5 = new int[5];
            int[] last4 = new int[4];
            for (int k = 0; k < first5.Length; k++)
            {
                first5[k] = int.Parse(words[k + 13]);
            }

            for (int l = 0; l < last4.Length; l++)
            {
                last4[l] = int.Parse(words[l + 18]);
            }
            Array.Sort(first5);
            Array.Reverse(first5);
            Array.Sort(last4);
            Array.Reverse(last4);
            int first5Sum = first5[0] + first5[1] + first5[2] + first5[3];
            int last4Sum = last4[0] + last4[1] + last4[2];
            int challangeSum = first5Sum + last4Sum;
            float portofolioMarkPercent = 100f * (float)challangeSum / 35f;
            float examMarkPercent = CalcExamMark(int.Parse(words[24]));
            int projectMark = int.Parse(words[26]);

            int moduleMark = (int)Math.Round((portofolioMarkPercent * digitalPortofolioWeighting / 100f) + (examMarkPercent * openBookWeighting / 100f) + (projectMark * capstoneWeighting / 100f));
            return moduleMark;
        }

        public static float CalcExamMark(float examMark)
        {
            float examMarkPercent = 100f * (float)examMark / 7f;
            return examMarkPercent;
        }

        public static float CalcProjectMark(float projectMark)
        {
            float projectMarkPercent = (float)Math.Round((float)projectMark, 2);
            return projectMarkPercent;
        }

        public static int ClassifyStudents(int moduleMark, string[] words)
        {
            float projectMarkPercent = CalcProjectMark(int.Parse(words[26]));

            float examMarkPercent = CalcExamMark(int.Parse(words[24]));
            if (moduleMark > 34 && (examMarkPercent < 40 || projectMarkPercent < 40))
            {
                moduleMark = 34;
            }
            if (moduleMark >= 70)
            {
                first++;
            }
            else if (moduleMark >= 60 && moduleMark < 70)
            {
                secondFirst++;
            }
            else if (moduleMark >= 50 && moduleMark < 60)
            {
                secondSecond++;
            }
            else if (moduleMark >= 40 && moduleMark < 50)
            {
                third++;
            }
            else
            {
                fail++;
            }
            return moduleMark;
        }
    }
}
```

## Test Plan

Include your test plan and results here

| Test Number | Input File | Expected Output | Output File | Comment | Pass/Fail |
|---|---|---|---|---|---|
| 1 | 1StudentFail33.mark | image.png | 1StudentFail33Output.txt | Files with just 1 student can help test individual paths through your code and identify bugs | Pass | 
| 2 | | | | | | 
| 3 | | | | | | 
| 4 | | | | | | 
| 5 | | | | | | 
| 6 | | | | | | 
| 7 | | | | | | 
| 8 | | | | | | 
| 9 | | | | | | 
| 10 | | | | | | 
| 11 | | | | | | 
| 12 | | | | | | 
| 13 | | | | | | 
1	1StudentFail33.markDownload	image.png	1StudentFail33Output.txtDownload 1StudentFail33Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
2	1StudentFail35.markDownload 1StudentFail35.mark	image.png	1StudentFail35Output.txtDownload 1StudentFail35Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
3	1StudentFail39.markDownload 1StudentFail39.mark	image.png	1StudentFail39Output.txtDownload 1StudentFail39Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
4	1StudentFailCappedCapstone34.markDownload 1StudentFailCappedCapstone34.mark	image.png	1StudentFailCappedCapstone34Output.txtDownload 1StudentFailCappedCapstone34Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
5	1StudentFailCappedExam34.markDownload 1StudentFailCappedExam34.mark	image.png	1StudentFailCappedExam34Output.txtDownload 1StudentFailCappedExam34Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
6	1StudentFailZeroMarks.markDownload 1StudentFailZeroMarks.mark	image.png	1StudentFailZeroMarksOutput.txtDownload 1StudentFailZeroMarksOutput.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
7	1StudentFirst71.markDownload 1StudentFirst71.mark	image.png	1StudentFirst71Output.txtDownload 1StudentFirst71Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
8	1StudentThird41.markDownload 1StudentThird41.mark	image.png	1StudentThird41Output.txtDownload 1StudentThird41Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
9	1StudentTwoOne61.markDownload 1StudentTwoOne61.mark	image.png	1StudentTwoOne61Output.txtDownload 1StudentTwoOne61Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
10	1StudentTwoTwo59.markDownload 1StudentTwoTwo59.mark	image.png	1StudentTwoTwo59Output.txtDownload 1StudentTwoTwo59Output.txt	Files with just 1 student can help test individual paths through your code and identify bugs	
11	5StudentsOneEachClassification.markDownload 5StudentsOneEachClassification.mark	image.png	5StudentsOneEachClassificationOutput.txtDownload 5StudentsOneEachClassificationOutput.txt	Files with a small number of students can help identify issues with counting the number of students in each classification and  sorting the output	
12	326Students.markDownload 326Students.mark	image.png	326StudentsOutput.txtDownload 326StudentsOutput.txt	Big data file	
## Feedback Request

If there is anything specific you want to ask for feedback on include that here
