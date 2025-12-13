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
	    Console.WriteLine(newList.Min());

	    LinkedList<int> intList = new LinkedList<int> {5, 2, 4};

	    intList.RemoveAt(1);
	    intList.AddRange(new int[] {7, 2, 9});
	    Console.WriteLine(intList);
	    intList.RemoveRange(2, 2);
	    Console.WriteLine(intList);
	    intList.InsertRange(2, new int[] {2, 3});
	    Console.WriteLine(intList);
	    Console.WriteLine(intList.Max());
	    Console.WriteLine(intList.Min());
	    Console.WriteLine(new int[] {2, 3});

	}
    }
}
