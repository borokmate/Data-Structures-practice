namespace MyApp
{
    class Program
    {
	static void Main(string[] args)
	{
	    Console.WriteLine("Hello, World!");
	    LinkedList<string> newList = new LinkedList<string>();

	    newList.Add("apple");
	    newList.Add("barack");
	    newList.Add("szilva");
	    newList.Add("körte");
	    newList.Add("kulcs");

	    newList.Remove("szilva");
	    newList.Insert(2, "kulcs");

	    Console.WriteLine(newList.Contains("szilva"));
	    Console.WriteLine(newList[3]);
	    Console.WriteLine(newList);
	    Console.WriteLine(newList.Count);
	    Console.WriteLine(newList.LastIndexOf("kulcs"));
	    Console.WriteLine(newList.IndexOf("kulcs"));
	}
    }
}
