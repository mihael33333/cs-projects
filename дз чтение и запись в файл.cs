using System.IO;
using System.Text;
using static System.Console;
namespace SimpleProject
{

    public class InfoToFile
    {
        const string filePath = "day17.txt";

        public string name = "";
        public DateOnly birth;
        public double[,] doubleArr = null;
        public int[,] intArr = null;


        public void writeToFile()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine($"{name} {birth}");
                    sw.WriteLine($"{doubleArr.GetLength(0)} {doubleArr.GetLength(1)}");
                    for (int i = 0; i < doubleArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < doubleArr.GetLength(1); j++)
                        {
                            sw.Write($"{doubleArr[i,j]} ");
                        }
                        sw.WriteLine();
                    }
                    sw.WriteLine($"{intArr.GetLength(0)} {intArr.GetLength(1)}");
                    for (int i = 0; i < intArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < intArr.GetLength(1); j++)
                        {
                            sw.Write($"{intArr[i, j]} ");
                        }
                        sw.WriteLine();
                    }

                    sw.WriteLine(DateTime.Now);
                }
            }
            WriteLine($"Успешно внесена информация в файл {filePath}");
        }

        public void readFromFile()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    WriteLine("Информация из файла:\n");
                    WriteLine(sr.ReadToEnd()); 
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double[,] doubleArr = new double[2, 3] { { 1.5, 3.12, 5.4 }, { 2.7, 5.8, 8.01 } };
            int[,] intArr = new int[2, 3] { { 15, 312, 4 }, { 27, 58, 801 } };

            InfoToFile f = new InfoToFile();
            f.doubleArr = doubleArr;
            f.intArr = intArr;
            f.name = "Timofey";
            f.birth = new DateOnly(1999, 3, 25);

            f.writeToFile();
            f.readFromFile();
        }
    }
}
