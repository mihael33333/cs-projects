using System.IO;
using System.Text;
using static System.Console;
namespace SimpleProject
{

    public class InfoToFile
    {
        
        private void writeToFile(string info)
        {
            const string filePath = "reversed.cs";

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine(info);
                }
            }
            WriteLine($"Успешно внесена информация в файл {filePath}");
        }

        public void readFromFile()
        {
            const string filePath = "test.cs";

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    WriteLine("Информация из файла:\n");
                    string info = sr.ReadToEnd();
                    info = info.Replace("public", "private").ToUpper();
                    info = info.Replace("    ", "");
                    info = new string(info.Reverse().ToArray());
                    Write(info);
                    writeToFile(info);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InfoToFile f = new InfoToFile();
            
            f.readFromFile();
        }
    }
}
