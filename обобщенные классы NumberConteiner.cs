using static System.Console;

public class NumberContainer<T> where T : struct, IComparable<T>
{
    public List<T> list { get; set; } = new List<T>();
    public void Add(T number)
    {
        list.Add(number);
    }
    public T Max() { return list.Max(); }
}
public class Program
{
    public static void Main(string[] args)
    {
        NumberContainer<double> a = new NumberContainer<double>();
        a.Add(52.4);
        a.Add(12.5);
        WriteLine(a.Max());
    }
}
