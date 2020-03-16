using System;
using System.Collections.Generic;
namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            myLinkedList kList = new myLinkedList();
            kList.AddSorted(5);
            kList.AddSorted(1);
            //kList.print();
            kList.AddSorted(0);
            //kList.print();
            kList.AddSorted(6);
            kList.AddSorted(8);
            kList.AddSorted(7);
            kList.AddSorted(2);
            kList.Remove(1);
            kList.print();
            kList.Clear();
            kList.print();
        }
    }
    class Node
    {
        public int data;
        public Node next;
        int counter;
        public Node(int x)
        {
            data = x;
            next = null;
        }

        public void print()
        {
            Console.Write("|" + data + "| -->");
            if (next != null)
            {
                next.print();
            }
        }

        public void AddAtEnd(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddAtEnd(data);
            }
        }

        public void AddSorted(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else if (next.data > data)
            {
                Node temp = new Node(data);
                temp.next = next;
                next = temp;
            }
            else
            {
                next.AddSorted(data);
            }
        }

        public void Remove(int data)
        {
            if (next.data == data)
            {
                next = next.next;
                // Does the garbage collector clean up the disconnected memory spaces???
            }
            else
            {
                next.Remove(data);
            }
        }
        public void checkIfExsists(int data)
        {            
            if (data == this.data)
            {                
                Console.WriteLine("match at index {0}", counter);
                counter++;
            }
            else if (next != null && next.data != data) 
            { 
                next.checkIfExsists(data);
            }            
        }
    }
    class myLinkedList
    {
        public Node headNode;
        public myLinkedList()
        {
            headNode = null;
        }

        public void print()
        {
            if (headNode == null)
            {
                Console.WriteLine("Nothing to print here!");
            }
            else
            {
                headNode.print();
            }
        }

        public void AddAtEnd(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                headNode.AddAtEnd(data);
            }
        }

        public void AddAtBegining(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                // i didn't get how the following code does the trick!
                headNode = temp;
            }
        }

        public void AddSorted(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else if (headNode.data <= data)
            {
                Node tempNode = headNode;
                while (tempNode.next != null && tempNode.next.data < data)
                {
                    tempNode = tempNode.next;
                }
                Node node = new Node(data);
                node.next = tempNode.next;
                tempNode.next = node;
            }
            else if (headNode.data > data)
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }
        }

        public void Remove(int data)
        {
            if (headNode != null)
            {
                headNode.Remove(data);
            }
            else
            {
                Console.WriteLine("Nothing to remove here!");
            }
        }
        public void Clear()
        {
            headNode = null;
        }
        public void checkIfExsists(int data)
        {
            if(headNode != null && headNode.data != data)
            {
                headNode.checkIfExsists(data);
            }
        }
    }
}
