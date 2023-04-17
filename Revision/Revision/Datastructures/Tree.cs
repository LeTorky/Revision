using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    public class BinaryTree
    {
        //Root Node
        private Node Root { get; set; }

        //Adds Data according to the BST Rules (Recursive Method)
        private void AddData(Node CurrentNode, int Data)
        {
            if (CurrentNode.Data > Data)
                if (CurrentNode.Left != null)
                    AddData(CurrentNode.Left, Data);
                else
                    CurrentNode.Left = new Node(Data);
            else
                if (CurrentNode.Right != null)
                AddData(CurrentNode.Right, Data);
            else
                CurrentNode.Right = new Node(Data);
        }

        //Invokes the Recursive method starting with the Root.

        public void AddData(int Data)
        {
            if (Root == null)
            {
                Root = new Node(Data);
            }
            else
            {
                AddData(Root, Data);
            }
        }

        //Traverses the tree in a PreOrder Manner (Root, Left, Right)

        private void Traverse(Node CurrentNode)
        {
            if (CurrentNode.Left != null)
            {
                Traverse(CurrentNode.Left);
            }
            Console.WriteLine(CurrentNode.Data);
            if (CurrentNode.Right != null)
            {
                Traverse(CurrentNode.Right);
            }
        }

        //Invokes the Traverse Method starting with Root Node.

        public void Traverse()
        {
            Traverse(Root);
        }

        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public Node(int SetData)
            {
                Data = SetData;
            }
            public Node() : this(0) { }
        }
    }
}
