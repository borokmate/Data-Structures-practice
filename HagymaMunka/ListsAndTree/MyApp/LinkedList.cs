namespace MyApp
{
    public class LinkedList<T> where T : IEquatable<T>
    {
	private class Node
	{
	    public T Value { get; set; }
	    public Node? Next { get; set; }

	    public Node(T value)
	    {
		Value = value;
		Next = null;
	    }
	}

	private Node? head;
	public int Count { private set; get; } = 0;

	public void Add(T value)
	{
	    if (head == null)
	    {
		head = new Node(value);
		Count++;
		return;
	    }

	    Node current = head;

	    while (current.Next != null)
		current = current.Next;

	    current.Next = new Node(value);
	    Count++;
	}

	public void Remove(T value)
	{
	    if (head == null)
		return;

	    Node current = head;

	    if (head.Value.Equals(value))
	    {
		head = current.Next;
		Count--;
		return;
	    }

	    while (current.Next != null)
	    {
		Node next = current.Next;

		if (next.Value.Equals(value))
		{
		    current.Next = next.Next;
		    Count--;
		    return;
		}

		current = current.Next;
	    }
	}

	public bool Contains(T value)
	{
	    if (head == null)
		return false;

	    Node current = head;

	    if (head.Value.Equals(value))
		return true;

	    while (current.Next != null)
	    {
		current = current.Next;

		if (current.Value.Equals(value))
		    return true;
	    }
	    
	    return false;
	}

        public override string ToString()
        {
	    if (head == null)
		return "";

            Node current = head;
	    
	    string output = "" + current.Value + (current.Next == null ? "" : ", ");

	    while (current.Next != null)
	    {
		current = current.Next;
		output = output + current.Value + (current.Next == null ? "" : ", ");
	    } 
	    return output;
        }

	public T this[int index]
	{
	    get
	    {
		Node? current = head;
		int i = 0;

		while (current != null)
		{
		    if (i == index)
			return current.Value;
		    current = current.Next;
		    i++;
		}
		throw new IndexOutOfRangeException();
	    }
	    set
	    {
		Node? current = head;
		int i = 0;

		while (current != null)
		{
		    if (i == index)
		    {
			current.Value = value;
			return;
		    }
		    current = current.Next;
		    i++;
		}
		throw new IndexOutOfRangeException();
	    }
	}

	public void Insert(int index, T value)
	{
	    Node? current = head;
	    int i = 0;

	    if (index == 0)
	    {
		Node newNode = new Node(value);
		newNode.Next = head;
		head = newNode;
		return;
	    }

	    while (current != null)
	    {
		if (i == index - 1)
		{
		    Node? next = current.Next;
		    Node newNode = new Node(value);
		    newNode.Next = next;
		    current.Next = newNode;
		    Count++;
		    return;
		}
		current = current.Next;
		i++;
	    }
	    throw new IndexOutOfRangeException();
	}

	public int IndexOf(T value)
	{
	    int index = 0;

	    Node? current = head;
	    
	    while (current != null)
	    {
		if (current.Value.Equals(value))
			return index;
		current = current.Next;
		index++;
	    }
	    
	    return -1;
	}
	public int LastIndexOf(T value)
	{
	    int index = -1;
	    int i = 0;
	    Node? current = head;
	    
	    while (current != null)
	    {
		if (current.Value.Equals(value))
			index = i;
		current = current.Next;
		i++;
	    }
	    return index;
	}
    }
}
