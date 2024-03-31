using System.Collections;

class LinkedList<T> : IEnumerable<T>
{
    private Element<T> _head;
    public int Count { get; set; }

    public void Add(T data)
    {
        Element<T> newelement = new Element<T>(data);
        newelement.Next = _head;
        _head = newelement;
        Count++;
    }

    public bool Remove(T data)
    {
        Element<T> previous = null;
        Element<T> current = FindElement(data, out previous);

        if (current != null)
        {
            if (previous != null)
            {
                previous.Next = current.Next;
            }
            else
            {
                _head = current.Next;
            }
            Count--;
            return true;
        }
        return false;
    }

    private Element<T> FindElement(T data, out Element<T> element)
    {
        element = null;
        Element<T> current = _head;

        while(current != null)
        {
            if(current.Data.Equals(data))
            {
                return current;
            }
            element = current;
            current = current.Next;
        }
        return null;
    }

    private Element<T> FindElementIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        Element<T> current = _head;
        for(int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }

    public T this[int index]
    {
        get
        {
            Element<T> element = FindElementIndex(index);

                if (element != null)
                {
                    return element.Data;
                }

            throw new IndexOutOfRangeException();
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(Element<T> current = _head; current != null; current = current.Next)
        {
            yield return current.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    internal class Element<T>
    {
        public T Data { get; set; }
        public Element<T> Next { get; set; }

        public Element(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
