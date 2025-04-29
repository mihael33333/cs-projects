using System.Text;
using static System.Console;

public class DICT
{
    public Dictionary<string, string> dict = new Dictionary<string, string>();
    //путь
    private string path = "C:\\Users\\Student\\source\\repos\\exam\\dictionary.txt";
    private bool IsEnglish_Russian = true;

    public DICT(bool IsEnRu = true)
    {
        IsEnglish_Russian = IsEnRu;
        readFromFile();
    }

    private void readFromFile()
    {
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                string info = sr.ReadToEnd();
                string a, b;
                foreach (string line in info.Split("\n"))
                {
                    if (line != "")
                    {
                        a = line.Split()[0];
                        b = line.Split()[1];
                        if (IsEnglish_Russian) dict[a] = b;
                        else dict[b] = a;
                    }
                    
                }
            }
        }
    }

    public void save()
    {
        using (FileStream fs = new FileStream(path, FileMode.Truncate))
        {
            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
            {

                foreach (string key in dict.Keys)
                {
                    string value = dict[key];
                    if (IsEnglish_Russian)
                    {
                        sw.Write($"{key} {value}");
                    }
                    else
                    {
                        sw.Write($"{value} {key}");
                    }
                    sw.WriteLine();
                }
                WriteLine("Изменения успешно внесены в файл.");
            }
        }
    }

    public override string ToString()
    {
        string s = "";
        foreach(string key in dict.Keys)
        {
            s += $"{key} - {dict[key]}\n";
        }
        return s;
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        Write("Выберите тип словаря. Англо-русский - 1 или русско-английский - 0. [1/0]: ");
        int op;
        op = int.Parse(ReadLine());
        DICT dict = null;
        if (op == 0) dict = new DICT(false);
        else dict = new DICT(true);

        WriteLine("Словарь создан!");


        const string menu = "\nВыберите действие:\n1 - перевести слово\n2 - добавить или изменить слово и перевод\n3 - удалить слово с переводом\n4 - напечатать словарь\n0 - выйти из программы";

        WriteLine(menu);
        op = int.Parse(ReadLine());

        string word = "", translation = "";
        while (op != 0)
        {
            if (op == 4)
            {
                WriteLine(dict);
            } else if (op < 1 || op > 3)
            {
                WriteLine("Неизвестная команда!");
            }
            else
            {
                Write("Введите слово: ");
                word = ReadLine();

                if (op == 1)
                {
                    if (dict.dict.ContainsKey(word))
                    {
                        WriteLine($"Перевод: {dict.dict[word]}");
                    }
                    else WriteLine("Такого слова нет в словаре!");
                }
                else if (op == 2)
                {
                    Write("Введите перевод: ");
                    translation = ReadLine();
                    dict.dict[word] = translation;
                    dict.save();
                }
                else if (op == 3)
                {
                    if (dict.dict.ContainsKey(word))
                    {
                        dict.dict.Remove(word);
                        dict.save();
                    }
                    else WriteLine("Такого слова нет в словаре!");
                }
            }
            WriteLine(menu);
            op = int.Parse(ReadLine());
        }
        
    }
}
