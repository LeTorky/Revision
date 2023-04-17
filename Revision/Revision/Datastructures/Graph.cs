using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    public class Graph
    {
        //Linked List of Vertices
        public LinkedList<GraphNode> Vertices;
        //Latest Key
        public int LatestKey;
        //Constructor
        public Graph()
        {
            //Create List of Vertices
            Vertices = new LinkedList<GraphNode>();
            //Sets Latest Key
            LatestKey = 0;
        }
        //Add new Vertix
        public void AddVertix(int SetData)
        {
            Vertices.AddLast(new GraphNode(SetData, ++LatestKey));
        }
        //Add Edge
        public void AddEdge(int FirstIndex, int SecondIndex)
        {
            Vertices.ElementAt(FirstIndex-1).AddAdjacent(Vertices.ElementAt(SecondIndex-1));
        }
        //Draw Adjacency Matrix
        public void DrawMatrix()
        {
            Console.Write("    ");
            foreach(GraphNode Node in Vertices)
            {
                Console.Write($"{Node.Key} ");
            }
            Console.Write("\n");
            Console.Write("    ");

            foreach (GraphNode Node in Vertices)
            {
                Console.Write("- ");
            }
            Console.Write("\n");
            foreach (GraphNode Node in Vertices)
            {
                Console.Write($"{Node.Key} | ");
                foreach(GraphNode TestingNode in Vertices)
                {
                    if (Node.CheckAdjacency(TestingNode))
                    {
                        TestingNode.PrintData();
                    }
                    else if(Node == TestingNode)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.Write("\n");
            }
        }
        //Draw Adjacency List
        public void DrawList()
        {
            foreach(GraphNode Node in Vertices)
            {
                Console.Write($"{Node.Key}");
                foreach(GraphNode AdjacentNodes in Vertices)
                {
                    if (AdjacentNodes.CheckAdjacency(Node))
                        Console.Write($"->{AdjacentNodes.Key}");
                }
                Console.WriteLine();
            }
        }

        //Node Class
        public class GraphNode
        {
            //Node's Data
            public int Data { get; set; }
            //Node's Key
            public int Key { get; private set; }
            //Node's References
            private LinkedList<GraphNode> Nodes { get; set; }
            //Node Constructor
            public GraphNode(int SetData, int SetKey)
            {
                //Setting Node's Key
                Key = SetKey;
                //Setting Node's Data
                Data = SetData;
                //Initializing Adjacent Nodes
                Nodes = new LinkedList<GraphNode>();
            }
            //Add Adjacent Node
            public void AddAdjacent(GraphNode AddNode)
            {
                //Adds it to current nodes references
                Nodes.AddLast(AddNode);
                //Adds current node to new nodes references
                AddNode.Nodes.AddLast(this);
            }
            //Print Node Data
            public void PrintData()
            {
                Console.Write($"{this.Data} ");
            }
            //Check Adjacency
            public Boolean CheckAdjacency(GraphNode TestNode)
            {
                return Nodes.Contains(TestNode);
            }
        }
    }
}  

