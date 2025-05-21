using System.Text;

namespace LinkedList.App.Models;

public class LinkedList<T>(Node<T> root)
{
    private Node<T>? Root { get; set; } = root;

    public void InsertAtBeginning(Node<T> node)
    {
        ArgumentNullException.ThrowIfNull(Root);

        node.AddNextNode(Root);

        Root = node;
    }

    public void InsertAtEnd(Node<T> node)
    {
        var current = Root;
        while (current is not null)
        {
            if (current.NextNode is null)
            {
                current.AddNextNode(node);
                current = null;
            }
            else
            {
                current = current.NextNode;
            }
        }
    }

    public void InsertBefore(Node<T> node, Node<T> newNode)
    {
        Node<T>? beforeCurrent = null;
        var current = Root;
        ArgumentNullException.ThrowIfNull(current);

        while (current is not null)
        {
            if (current == node)
            {
                if (beforeCurrent is null)
                {
                    InsertAtBeginning(newNode);
                }
                else
                {
                    newNode.AddNextNode(current);
                    beforeCurrent.AddNextNode(newNode);
                }

                return;
            }

            beforeCurrent = current;
            current = current.NextNode;
        }
    }

    public void InsertAfter(Node<T> node, Node<T> newNode)
    {
        var current = Root;
        ArgumentNullException.ThrowIfNull(current);

        while (current is not null)
        {
            if (current == node)
            {
                if (current.NextNode is not null)
                {
                    newNode.AddNextNode(current.NextNode);
                }

                current.AddNextNode(newNode);
                return;
            }

            current = current.NextNode;
        }
    }

    public Node<T>? Find(int position)
    {
        var current = Root;
        ArgumentNullException.ThrowIfNull(current);

        var startPosition = 0;
        while (current is not null)
        {
            if (startPosition == position)
            {
                return current;
            }

            current = current.NextNode;
            startPosition++;
        }

        return null;
    }

    public void DeleteAtBeginning()
    {
        var current = Root;
        ArgumentNullException.ThrowIfNull(current);

        if (current.NextNode is not null)
        {
            Root = current.NextNode;
        }
    }

    public void DeleteAtEnd()
    {
        Node<T>? beforeCurrent = null;
        var current = Root;
        ArgumentNullException.ThrowIfNull(current);

        while (current is not null)
        {
            if (current.NextNode is null)
            {
                beforeCurrent?.AddNextNode(null!);
                
                return;
            }

            beforeCurrent = current;
            current = current.NextNode;
        }
    }

    public void DeleteFromPosition(int position)
    {
        Node<T>? beforeCurrent = null;
        var current = Root;
        ArgumentNullException.ThrowIfNull(current);
        
        var startPosition = 0;
        while (current is not null)
        {
            if (startPosition == position)
            {
                if (beforeCurrent is not null)
                {
                    beforeCurrent.AddNextNode(current.NextNode!);
                }
                else
                {
                    if (current.NextNode is not null)
                    {
                        DeleteAtBeginning();
                    }
                }
                
                return;
            }

            beforeCurrent = current;
            current = current.NextNode;

            startPosition++;
        }
    }

    public override string ToString()
    {
        var current = Root;

        if (current is null)
        {
            return "Empty";
        }

        var builder = new StringBuilder();
        while (current is not null)
        {
            builder.Append(current.Value);
            if (current.NextNode is not null)
            {
                builder.Append(" -> ");
            }

            current = current.NextNode;
        }

        return builder.ToString();
    }
}