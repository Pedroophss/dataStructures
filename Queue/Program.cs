using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue1
{
    class Program
    {
        public class MyQueue<TNode>
        {
            private Node<TNode> Head;
            private Node<TNode> Tail;

            private class Node<TNode>
            {
                public TNode Data;
                public Node<TNode> Right { get; set; }
                public Node<TNode> Left { get; set; }

                public Node(TNode data)
                {
                    Data = data;
                }

                public override string ToString()
            {
                return Data.ToString();
            }
            }

            public void SetNewHead(TNode data)
            {
                Node<TNode> NewItem = new Node<TNode>(data); ;
                if (Head == null)
                {
                    Head = NewItem;
                }
                else
                {
                    NewItem.Left = Head;
                    Head = NewItem;
                }
            }

            public void AddItem(TNode data)
            {
                if (Head == null)
                {
                    SetNewHead(data);
                }
                else
                {
                    Node<TNode> Current = Head;
                    while (Current.Left != null)
                    {
                        Current = Current.Left;
                    }
                    Node<TNode> NewItem = new Node<TNode>(data);
                    Current.Left = NewItem;
                    NewItem.Right = Current;
                    Tail = NewItem;
                }
            }

            public void AddAtIndex(TNode data, int index)
            {
                if (index == 0)
                {
                    SetNewHead(data);
                }
                else
                {
                    Node<TNode> Current = Head;
                    int count = 0;
                    while (Current != null)
                    {
                        if ((count + 1) == index)
                        {
                            Node<TNode> NewNode = new Node<TNode>(data);
                            NewNode.Right = Current;
                            if (Current.Left != null)
                            {
                                Current.Left.Right = NewNode;
                            }
                            NewNode.Left = Current.Left;
                            Current.Left = NewNode;
                            Tail = NewNode.Left == null ? NewNode : Tail;
                        }
                        Current = Current.Left;
                        count++;
                    }
                }
            }

            public void DeleteItem(TNode data)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Left;
                }

                Node<TNode> Current = Head;
                while (Current.Left != null)
                {
                    if (Current.Left.Data.Equals(data))
                    {
                        Current.Left = Current.Left.Left;
                    }
                    Current = Current.Left;
                }
            }

            public void DeleteByIndex(int index)
            {
                Node<TNode> Current = Head;
                int count = 0;
                if (index == 0)
                {
                    DeleteItem(Head.Data);
                }
                while (Current != null)
                {
                    if (index == count)
                    {
                        DeleteItem(Current.Data);
                    }
                    Current = Current.Left;
                    count++;
                }
            }

            public void SearchItem(int index)
            {
                Node<TNode> Current = Head;
                int count = 0;
                if (index == 0)
                {
                    Console.WriteLine(Current.Data);
                }
                while (Current != null)
                {
                    if (count == index)
                    {
                        Console.WriteLine(Current.Data);
                    }

                    Current = Current.Left;
                    count++;
                }
            }
        }

        static void Main(string[] args)
        {
            
        }
    }
}
