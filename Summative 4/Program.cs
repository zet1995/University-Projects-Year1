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
