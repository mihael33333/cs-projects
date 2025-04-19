using static System.Console;

public class Counter<T>
{
    public List<T> List { get; set; } = new List<T>();

    public void Add(T item) {  List.Add(item); }
    public int Count() { return List.Count; }
}
public class Program
{
    public static void Main(string[] args)
    {
        Counter<double> counter = new Counter<double>();
        counter.Add(32.33);
        counter.Add(45.12);

        WriteLine(counter.Count());
    }
}
