//using Revision.DSAlg;
//using Revision.EF;
//using System.Data;
//using System.Data.SqlClient;
//namespace Revision
//{
//    internal class Program
//    {
//        #region DataStructures and Algorithms
//        public static void Main()
//        {
//            #region Stack
//            Stack Stack = new Stack();
//            Stack.Push(5);
//            Stack.Push(4);
//            Stack.Push(3);
//            Stack.Push(2);
//            Stack.Push(1);
//            Stack.Pop();
//            Stack.Pop();
//            #endregion

//            #region Double Linked List
//            DoubleLinkedList NewList = new DoubleLinkedList();
//            NewList.Append(5);
//            NewList.Append(3);
//            NewList.Append(1);
//            NewList.InsertBefore(4, 2);
//            NewList.InsertAfter(2, 3);
//            NewList.Remove(2);
//            NewList.Remove(2);
//            NewList.PrintAll();
//            #endregion

//            #region Queue
//            Queue Queue = new Queue();
//            Queue.Push(5);
//            Queue.Push(4);
//            Console.WriteLine(Queue.Pop());
//            Console.WriteLine(Queue.Pop());
//            Queue.Push(3);
//            Console.WriteLine(Queue.Pop());
//            #endregion

//            #region BinaryTree
//            BinaryTree BinaryTree = new BinaryTree();
//            BinaryTree.AddData(1);
//            BinaryTree.AddData(5);
//            BinaryTree.AddData(2);
//            BinaryTree.AddData(4);
//            BinaryTree.AddData(3);
//            BinaryTree.Traverse();
//            #endregion

//            #region 2D Array
//            int[,] TwoDArray = new int[2, 3];
//            for (int i = 0; i < TwoDArray.Rank; i++)
//            {
//                for (int y = 0; y < TwoDArray.LongLength / TwoDArray.Rank; y++)
//                {
//                    TwoDArray[i, y] = i != 0 ? TwoDArray[i - 1, TwoDArray.LongLength / TwoDArray.Rank - 1] + y + 1 : y;
//                    Console.WriteLine(TwoDArray[i, y]);
//                }
//            }
//            #endregion

//            #region Jagged Array
//            int[][] JaggedArray = new int[2][];
//            for (int i = 1; i <= 2; i++)
//            {
//                JaggedArray[i - 1] = new int[i];
//            }
//            for (int i = 0; i < 2; i++)
//            {
//                for (int y = 0; y < JaggedArray[i].Length; y++)
//                {
//                    JaggedArray[i][y] = y;
//                    Console.WriteLine(JaggedArray[i][y]);
//                }
//            }
//            #endregion

//            #region Binary Search
//            BinarySearch BinarySearch = new BinarySearch();
//            Console.WriteLine(BinarySearch.Search(5));
//            Console.WriteLine(BinarySearch.Search(10));
//            #endregion

//            #region Bubble Sort
//            BubbleSort BubbleSort = new BubbleSort();
//            BubbleSort.Print();
//            BubbleSort.Sort();
//            BubbleSort.Print();
//            #endregion

//            #region BinarySort
//            BinarySort BinarySort = new BinarySort();
//            BinarySort.Print();
//            BinarySort.Sort();
//            BinarySort.Print();
//            #endregion
//        }
//        #endregion

//        #region OOP
//        public static void Main()
//        {

//        }
//        #endregion

//        #region EF and ADO.NET
//        public static void Main()
//        {
//            #region ADO.NET
//            #region Connected Model
//            SqlConnection Connection = new SqlConnection();
//            Connection.ConnectionString = "Server=.;Database=ITICOMPSYSDB2;Trusted_Connection=True;Connection Timeout=30";
//            Connection.Open();
//            SqlCommand Command = new SqlCommand("SELECT FullNameEn FROM Students, AspNetUsers WHERE Students.Id = AspNetUsers.Id");
//            Command.Connection = Connection;
//            SqlDataReader Reader = Command.ExecuteReader();

//            while (Reader.Read())
//            {
//                Console.WriteLine(Reader[0]);
//            }
//            Reader.Close();
//            Connection.Close();
//            #endregion

//            #region Disconnected Model
//            Console.WriteLine("\n");
//            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT FullNameEn FROM Students, AspNetUsers WHERE Students.Id = AspNetUsers.Id", Connection);
//            DataSet DataSet = new DataSet();
//            Adapter.Fill(DataSet, "Students");
//            Console.WriteLine(DataSet.Tables["Students"].Rows[0][0]);
//            #endregion

//            #region Disconencted Model with custom DataSet
//            DataTable Table = new DataTable("CustomStudents");
//            DataColumn Column = new DataColumn("FullNameEn");
//            Table.Columns.Add(Column);
//            for (int i = 0; i < DataSet.Tables["Students"].Rows.Count; i++)
//            {
//                DataRow Row = Table.NewRow();
//                Row["FullNameEn"] = DataSet.Tables["Students"].Rows[i]["FullNameEn"];
//                Table.Rows.Add(Row);
//            }
//            Console.WriteLine(Table.Rows[0]["FullNameEN"]);
//            #endregion
//            #endregion

//            #region EF
//            Context Context = new Context();
//            Context.Students.ToList().ForEach(S => Console.WriteLine(S.Name));
//            #endregion
//        }
//        #endregion
//    }
//}
