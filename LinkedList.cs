using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MyLinkedList<TNode>
    {
        private Node<TNode> Head;

        private class Node<TNode>
        {
            public TNode Data;
            public Node<TNode> Right { get; set; }

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
            if (Head == null)
            {
                Head = new Node<TNode>(data);
            }
            else
            {
                Node<TNode> NewHead = new Node<TNode>(data);
                NewHead.Right = Head;
                Head = NewHead;
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
                while (Current.Right != null)
                {
                    Current = Current.Right;
                }
                Current.Right = new Node<TNode>(data);
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
                        NewNode.Right = Current.Right;
                        Current.Right = NewNode;
                    }
                    Current = Current.Right;
                    count++;
                }
            }
        }

        public void DeleteItem(TNode data)
        {
            if (Head.Data.Equals(data))
            {
                Head = Head.Right;
            }

            Node<TNode> Current = Head;
            while (Current != null)
            {
                if (Current.Right.Data.Equals(data))
                {
                    Current.Right = Current.Right.Right;
                }
                Current = Current.Right;
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
                Current = Current.Right;
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

                Current = Current.Right;
                count++;
            }
        }
    }
}
