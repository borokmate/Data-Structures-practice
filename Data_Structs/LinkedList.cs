using System.Collections;

namespace Data_Structs
{
    public class LinkedList<T> : IEnumerable<T> where T : IEquatable<T>, IComparable<T>
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
	public int Count { get; private set; } = 0;

	/// <summary>
	/// Creates a linked list with only the head value
	/// </summary>
	/// <param name="value">The value of head</param>
	public LinkedList(T value)
	{
	    head = new Node(value);
	}

	public LinkedList() { }

	/// <summary>
	/// Clears the list
	/// </summary>
	public void Clear()
	{
	    head = null;
	}

	/// <summary>
	/// Adds a new element with a given value to the end of the list
	/// </summary>
	/// <param name="value">The value that gets added</param>
	/// <returns>void</returns>
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

	/// <summary>
	/// Adds a range of elements to the end of the list
	/// </summary>
	/// <param name="newRange">The range that gets added to the end</param>
	/// <returns>void</returns>
	public void AddRange(T[] newRange)
	{
	    foreach (T newValue in newRange)
		Add(newValue);
	}

	// Needed to make array assignment possible
	public IEnumerator<T> GetEnumerator()
	{
	    Node? current = head;
	    while (current != null)
	    {
		yield return current.Value;
		current = current.Next;
	    }
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>
	/// Removes a value specified from the list
	/// </summary>
	/// <param name="value">The value gets removed</param>
	/// <returns>void</returns>
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

	/// <summary>
	/// It removes from the list at the specified index
	/// </summary>
	/// <param name="newRange">The index where the list is removed from</param>
	/// <returns>void</returns>
	public void RemoveAt(int index)
	{
	    if (head == null)
		return;

	    int i = 0;
	    Node current = head;

	    if (index == 0)
	    {
		head = current.Next;
		Count--;
		return;
	    }

	    while (current.Next != null)
	    {
		Node next = current.Next;

		if (i == index - 1)
		{
		    current.Next = next.Next;
		    Count--;
		    return;
		}

		i++;
		current = next;
	    }
	    throw new IndexOutOfRangeException();
	}
	
	/// <summary>
	/// Removes a given count of elements from a specified index
	/// </summary>
	/// <param name="index">The start index where the removing will start from</param>
	/// <param name="count">Removes the specified amount of elements</param>
	/// <returns>void</returns>
	public void RemoveRange(int index, int count)
	{
	    for (int i = 0; i < count; i++)
		RemoveAt(index);
	}

	/// <summary>
	/// Returns true if the specified value is in the list
	/// </summary>
	/// <param name="value">The value checked for</param>
	/// <returns>bool</returns>
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

	/// <summary>
	/// Prints the list's elements out with commas inbetween 
	/// </summary>
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

	// Just casual indexing
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

	/// <summary>
	/// Inserts an element at a given index 
	/// </summary>
	/// <param name="index">The index where the element is inserted</param>
	/// <param name="value">The value that gets added</param>
	/// <returns>void</returns>
	public void Insert(int index, T value)
	{
	    Node? current = head;
	    int i = 0;

	    if (index == 0)
	    {
		Node newNode = new Node(value);
		newNode.Next = head;
		head = newNode;
		Count++;
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
	
	/// <summary>
	/// Inserts a range of elements at a given index
	/// </summary>
	/// <param name="index">The index where the range is inserted into</param>
	/// <param name="newRange">The range that gets inserted</param>
	/// <returns>void</returns>
	public void InsertRange(int index, T[] newRange)
	{
	    for (int i = newRange.Length - 1; i >= 0; i--)
		Insert(index, newRange[i]);
	}
	
	/// <summary>
	/// Returns the index of a value in the list, if not found returns -1
	/// </summary>
	/// <param name="value">The value that the search is done for</param>
	/// <returns>int</returns>
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

	/// <summary>
	/// Returns the last index where the value is found, if not found returns -1
	/// </summary>
	/// <param name="value">The value that the search is done for</param>
	/// <returns>int</returns>
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

	/// <summary>
	/// Checks if the list is empty
	/// </summary>
	/// <returns>bool</returns>
	public bool IsEmpty()
	{
	    return head == null;
	}

	/// <summary>
	/// Returns the maximum value of the list
	/// If it's a number it'll return the biggest, if it's a word it's returns the latest in alphabetical order
	/// </summary>
	/// <returns><typeparamref name="T"/></returns>
	public T Max()
	{
	    if (head == null)
		throw new InvalidOperationException("The list is empty");

	    T max = head.Value;
	    Node? current = head.Next;

	    while (current != null)
	    {
		if (current.Value.CompareTo(max) > 0)
		    max = current.Value;
		current = current.Next;
	    }
	    return max;
	}
	
	/// <summary>
	/// Returns the minimum value of the list
	/// If it's a number it'll return the smallest, if it's a word it's returns the earliest in alphabetical order
	/// </summary>
	/// <returns><typeparamref name="T"/></returns>
	public T Min()
	{
	    if (head == null)
		throw new InvalidOperationException("The list is empty");

	    T min = head.Value;
	    Node? current = head.Next;

	    while (current != null)
	    {
		if (current.Value.CompareTo(min) < 0)
		    min = current.Value;
		current = current.Next;
	    }
	    return min;
	}
    }
}
