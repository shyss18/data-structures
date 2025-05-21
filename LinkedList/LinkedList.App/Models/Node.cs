namespace LinkedList.App.Models;

public class Node<T>(T value)
{
    public T Value { get; } = value;

    public Node<T>? NextNode { get; private set; }

    public void AddNextNode(Node<T> node)
    {
        NextNode = node;
    }

    public override string ToString()
    {
        return $"Value: {Value}, HasNextNode: {NextNode is not null}";
    }
}