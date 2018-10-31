using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInternals
{
    public class MyLinkedList<T>
    {
        public MyLinkedList(LinkedListNode<T> rootNode)
        {
            this.RootNode = rootNode;
        }

        public LinkedListNode<T> RootNode
        {
            get; private set;
        }

        public void AddNode(T value)
        {
            var currNode = this.RootNode;
            //find the last node in the list
            while (currNode.Next != null)
            {
                currNode = currNode.Next;
            }
            currNode.Next = new LinkedListNode<T>(value);
        }
    }

    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get; set;
        }

        public LinkedListNode<T> Next
        {
            get; set;
        }
    }
}
