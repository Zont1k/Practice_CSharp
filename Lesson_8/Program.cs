using Lesson_8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

class LinkedList<T> : IEnumerable<T>
{
    private Element<T> _head;
    public int Count { get; set; }

    int currentIndex = 0;

    public void Add(T data)
    {
        Element<T> newelement = new Element<T>(data);
        newelement.Next = _head;
        _head = newelement;
        Count++;
    }

    public bool Remove(T data)
    {
        Element<T> current = _head;
        Element<T> previous = null;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    public object this[int index]
    {
        get
        {
            Element<T> current = _head;

            for (int i = 0; current != null; i++)
            {
                if (i == index)
                {
                    return current.Data;
                }
                current = current.Next;
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
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> intList = new LinkedList<int>();

        intList.Add(1);
        intList.Add(2);
        intList.Add(3);

        foreach (var item in intList)
        {
            Console.WriteLine(item);
        }

        LinkedList<string> stringList = new LinkedList<string>();

        stringList.Add("Hello");
        stringList.Add("World");
        stringList.Add("!");

        for (int i = 0; i < stringList.Count; i++)
        {
            Console.WriteLine(stringList[i]);
        }
    }
}
