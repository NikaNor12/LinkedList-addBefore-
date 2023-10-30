using System.Collections;

namespace G1720232410;

public class MyLinkedList<T> : ICollection<T>
{
    private MyLinkedListNode<T>? _first;
    private MyLinkedListNode<T>? _last;

    public void AddFirst(MyLinkedListNode<T> node)
    {
        if (_first == null)
        {
            _first = _last = node;
            return;
        }
        node.Next = _first;
        _first = node;
    }

    public MyLinkedListNode<T> AddFirst(T value)
    {
        MyLinkedListNode<T> node = new(value);
        AddFirst(node);
        return node;
    }

    public void AddLast(MyLinkedListNode<T> node)
    {
        if (_last == null)
        {
            _first = _last = node;
            return;
        }
        node.Next = node;
        _last = node;
    }

    public MyLinkedListNode<T> AddLast(T value)
    {
        MyLinkedListNode<T> node = new(value);
        AddLast(node);
        return node;
    }

    public void Remove(MyLinkedListNode<T> node)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
       throw new NotImplementedException();
    }


    public void RemoveFirst()
    {
        //Remove(_first);
        _first = _first.Next;
    }

    public void RemoveLast()
    {
        //Remove(_last);
        _last = _last.Previous;
        _last.Next = null;
    }

    public void Clear()
    {
        _first = null;
        _last = null;
    }

    public bool Contains(T value)
    {
        MyLinkedListNode<T> current = _first;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public MyLinkedListNode<T>? Find(T value)
    {
        MyLinkedListNode<T>? node = _first;

        while (node != null)
        {
            if (node.Value!.Equals(value))
            {
                return node;
            }
            node = node.Next;
        }

        return null;
    }

    public MyLinkedListNode<T>? FindLast(T value)
    {
        MyLinkedListNode<T>? current = _first;
        MyLinkedListNode<T>? lastMatch = null;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                lastMatch = current;
            }
            current = current.Next;
        }

        return lastMatch;
    }


    public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        newNode.Next = node.Next;
        node.Next = newNode;
    }

    public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
    {
        MyLinkedListNode<T> newNode = new(value);
        AddAfter(node, newNode);
        return newNode;
    }

    public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        MyLinkedListNode<T> current = _first;

        while (current != null && current.Next != node)
        {
            current = current.Next;
        }
        newNode.Next = node;
        current.Next = newNode;

    }


    public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
    {
        MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);
        AddBefore(node, newNode);
        return newNode;
    }


    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyLinkedListEnumerator<T>(_first);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotImplementedException();
    }
}

public class MyLinkedListEnumerator<T> : IEnumerator<T>
{
    private MyLinkedListNode<T> _first;
    private MyLinkedListNode<T>? _current;

    public MyLinkedListEnumerator(MyLinkedListNode<T> first)
    {
        _first = first;
    }

    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = _first;
            return true;
        }

        if (_current.Next != null)
        {
            _current = _current.Next;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _current = null;
    }

    public T Current => _current.Value;

    object IEnumerator.Current => Current;

    public void Dispose()
    {

    }
}