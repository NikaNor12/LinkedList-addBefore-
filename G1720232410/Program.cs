namespace G1720232410
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MyLinkedList<string> linkedList = new();
			linkedList.AddFirst("1");
			linkedList.AddFirst("2");
			
			linkedList.AddFirst(new MyLinkedListNode<string>("3"));
			linkedList.AddFirst("4");
			linkedList.AddFirst("5");

			MyLinkedListNode<string>? node = linkedList.Find("2");

			if (node != null)
			{
				linkedList.AddBefore(node, "53");
                //linkedList.AddAfter(node, "53");
            }

			foreach (var item in linkedList)
			{
				Console.WriteLine(item);
			}

			//MyLinkedListNode<string> node1 = new("Nini");
			//MyLinkedListNode<string> node2 = new("Tako");
			//MyLinkedListNode<string> node3 = new("Tiko");
			//MyLinkedListNode<string> node4 = new("Luka");
			//MyLinkedListNode<string> node5 = new("Giorgi");

			//node1.Next = node2;
			//node2.Next = node3;
			//node3.Next = node4;
			//node4.Next = node5;

			//Print(node1);
		}

		static void Print(MyLinkedListNode<string>? node)
		{
			do
			{
				Console.WriteLine(node);
				node = node?.Next;
			}
			while (node != null);
		}

		//static void Print(MyLinkedListNode<string> node)
		//{
		//	Console.WriteLine(node);
		//	if (node.Next != null)
		//	{
		//		Print(node.Next);
		//	}
		//}
	}
}