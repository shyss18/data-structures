using LinkedList.App.Models;

var linkedList = new LinkedList.App.Models.LinkedList<int>(new Node<int>(1));

Console.WriteLine($"Initial {linkedList}");

linkedList.InsertAtEnd(new Node<int>(2));

linkedList.InsertAtEnd(new Node<int>(5));

linkedList.InsertAtEnd(new Node<int>(6));

Console.WriteLine($"After inserting at the end {linkedList}");

linkedList.InsertAtBeginning(new Node<int>(0));

linkedList.InsertAtBeginning(new Node<int>(-1));

Console.WriteLine($"After inserting at the beginning {linkedList}");

const int position = 2;
var fifthItem = linkedList.Find(position);

Console.WriteLine($"Item at position {position} - {fifthItem}");

if (fifthItem != null)
{
    linkedList.InsertBefore(fifthItem, new Node<int>(10));
}

Console.WriteLine($"After insert before item - {fifthItem}\n{linkedList}");

if (fifthItem != null)
{
    linkedList.InsertAfter(fifthItem, new Node<int>(11));
}

Console.WriteLine($"After insert after item - {fifthItem}\n{linkedList}");

linkedList.DeleteAtBeginning();

Console.WriteLine($"After delete at the beginning {linkedList}");

linkedList.DeleteAtEnd();

Console.WriteLine($"After delete at the end {linkedList}");

linkedList.DeleteFromPosition(position);

Console.WriteLine($"After delete from position {position} - {linkedList}");
