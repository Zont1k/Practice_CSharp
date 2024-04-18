using System;
using System.Collections.Generic;
using System.Xml.Linq;

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
