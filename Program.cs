using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfNodesInList = 16;
            var cycleSize = 4;


            var range = Enumerable.Range(1, numberOfNodesInList);
            var n = new Node<int>(0);
            var head = n;
            foreach(var i in range) {
              n.Next = new Node<int>(i); n = n.Next;
            }
            head = head.Next;
            n = head;
            Console.WriteLine("Input list");
            PrintList(head);

            var count = 1;
            Node<int> result = null;
            Node<int> resultHead = null;
            var tempHolder = new Stack<int>();

            while (n != null)
            {
                var iteration = count / cycleSize;
                //Console.WriteLine("working with {0}", n.data);
                if (result == null)
                {
                    //Console.WriteLine("result is null so adding first element.");
                    result = new Node<int>(n.data);
                    resultHead = result;
                    n = n.Next;
                    continue;
                }
                if (iteration % 2 == 1)
                {
                    //Console.WriteLine("Push {0} to stack", n.data);
                    tempHolder.Push(n.data);
                }
                else {
                    while (tempHolder.Count > 0)
                    {
                        result.Next = new Node<int>(tempHolder.Pop());
                        result = result.Next;
                        //Console.WriteLine("Added {0} to result", result.data);
                    }
                    //Console.WriteLine("adding {0} to result.", n.data);
                    result.Next = new Node<int>(n.data);
                    result = result.Next;
                }
                n = n.Next;
                count++;
            }
            while (tempHolder.Count > 0)
            {
                result.Next = new Node<int>(tempHolder.Pop());
                result = result.Next;
                //Console.WriteLine("Added {0} to result", result.data);
            }

            Console.WriteLine("Return list");
            PrintList(resultHead);
        }

        static void PrintList<T>(Node<T> node)
        {
            var startPointer = node;
            while (startPointer.Next != null)
            {
                Console.Write(startPointer.data.ToString() + "->");
                startPointer = startPointer.Next;
            }
            Console.WriteLine(startPointer.data);
        }
    }

    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T d)
        {
            data = d;
        }
    }
}
