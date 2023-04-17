namespace Revision.DSAlg
{
    //Delegates for Node manipulation
    public delegate void Actioner<T>(T OperationalNode);

    //Node Class
    class Node
    {
        //Node Constructor
        public Node() : base() { }
        public Node(int SetData = 0)
        {
            Left = Right = null;
            Data = SetData;
        }

        //Left and Right Node References
        public Node Left { get; set; }
        public Node Right { get; set; }

        //Node Data
        public int Data { get; set; }
    }

    //Double Linked List Clas
    public class DoubleLinkedList
    {
        //Head and Tail of Double Linked List
        private Node Head = null;
        private Node Tail = null;

        //Linked List Length
        public int Length { get; private set; }

        //Append method to end of Linked List.
        public void Append(int SetData)
        {
            if (Tail == null)
            {
                Head = Tail = new Node(SetData);
            }
            else
            {
                Tail.Right = new Node(SetData);
                Tail.Right.Left = Tail;
                Tail = Tail.Right;
                ++Length;
            }
        }

        //Finds node required at given index and invokes passed Delegate with Node.
        private void FindIndex(int SetData, int StartIndex, int EndIndex, Node CurrentNode, Actioner<Node> Del)
        {
            if (CurrentNode.Right == null && StartIndex != EndIndex)
            {
                throw new Exception("Exceeded Index");
            }
            if (StartIndex == EndIndex)
            {
                Del(CurrentNode);
            }
            else
            {
                FindIndex(SetData, ++StartIndex, EndIndex, CurrentNode.Right, Del);
            }

        }

        //Gets Data by using FindIndex and Printing out its content.
        public void GetData(int Index)
        {
            if (Head == null || Index < 1)
            {
                throw new Exception("No Nodes Inserted");
            }
            FindIndex(0, 0, Index - 1, Head, (CurrentNode) =>
            {
                Console.WriteLine(CurrentNode.Data);
            });
        }

        //Inserts node after a specific Index by using FindIndex.
        public void InsertAfter(int SetData, int Index)
        {
            if (Head == null || Index < 1)
            {
                throw new Exception("No Nodes Inserted");
            }
            FindIndex(SetData, 0, Index - 1, Head, (CurrentNode) =>
            {
                Node NewNode = new Node(SetData);
                NewNode.Left = CurrentNode;
                NewNode.Right = CurrentNode.Right;
                if (CurrentNode.Right != null)
                    CurrentNode.Right.Left = NewNode;
                CurrentNode.Right = NewNode;
                Tail = Tail == CurrentNode ? NewNode : Tail;
                ++Length;
            });
        }

        //Inserts node before a specific Index by using FindIndex.
        public void InsertBefore(int SetData, int Index)
        {
            if (Head == null || Index < 1)
            {
                throw new Exception("No Nodes Inserted");
            }
            FindIndex(SetData, 0, Index - 1, Head, (CurrentNode) =>
            {
                Node NewNode = new Node(SetData);
                NewNode.Right = CurrentNode;
                NewNode.Left = CurrentNode.Left;
                if (CurrentNode.Left != null)
                    CurrentNode.Left.Right = NewNode;
                CurrentNode.Left = NewNode;
                Head = Head == CurrentNode ? NewNode : Head;
                ++Length;
            });
        }

        //Removes a specific node at a specific Index by using FindIndex.
        public void Remove(int Index)
        {
            if (Head == null || Index < 1)
            {
                throw new Exception("No Nodes Inserted");
            }
            FindIndex(0, 0, Index - 1, Head, (CurrentNode) =>
            {
                Node NodeRight = CurrentNode.Right;
                Node NodeLeft = CurrentNode.Left;
                if (CurrentNode == Head)
                {
                    Head = CurrentNode.Right;
                    if (NodeRight != null)
                        NodeRight.Left = null;
                }
                if (CurrentNode == Tail)
                {
                    Tail = CurrentNode.Left;
                    if (NodeLeft != null)
                        NodeLeft.Right = null;
                }
                if (NodeRight != null)
                    NodeRight.Left = NodeLeft;
                if (NodeLeft != null)
                    NodeLeft.Right = NodeRight;
                --Length;
            });
        }

        //Keeps printing node data until reaches null.
        private void PrintNext(Node CurrentNode)
        {
            Console.WriteLine(CurrentNode.Data.ToString());
            if (CurrentNode.Right != null)
                PrintNext(CurrentNode.Right);
        }

        //Prints all data by invoking PrintNext with Head.
        public void PrintAll()
        {
            if (Head == null)
            {
                throw new Exception("No Nodes Inserted");
            }
            PrintNext(Head);
        }

    }

}

