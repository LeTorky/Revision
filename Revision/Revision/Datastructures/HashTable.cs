using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DSAlg
{
    public class HashTable
    {
        //Data Container
        private LinkedList<HashNode>[] Bucket { get; set; }
        //Constructor
        public HashTable(int BucketSize)
        {
            Bucket = new LinkedList<HashNode>[BucketSize];
        }
        //Hashing Function
        public int HashFn(string Key)
        {
            int HashedKey = 0;
            //Handling empty or null keys
            if (String.IsNullOrEmpty(Key))
                throw new Exception("Key is Empty!");
            for(int i=0; i<Key.Length; i++)
            {
                HashedKey += (int)((int)Key[i] * Math.Pow(31, i));
            }
            return MappingFn(HashedKey);
        }
        //Mapping Function
        public int MappingFn(int Index)
        {
            return Index % Bucket.Length;
        }
        //Add Node
        public void Add(string Key, int Value)
        {
            int HashedKey = HashFn(Key);
            if (Bucket[HashedKey] == null)
                Bucket[HashedKey] = new LinkedList<HashNode>();
            Bucket[HashedKey].AddLast(new HashNode(Key, Value));
        }
        //Get Node
        public void Get(string Key)
        {
            int HashedKey = HashFn(Key);
            HashNode Node = Bucket[HashedKey].Where(Node => Node.Key == Key).FirstOrDefault();
            Console.WriteLine($"Node:\nIndex:{HashedKey} Key:{Node.Key} Data:{Node.Data}");
        }
        //Hash Node Class
        public class HashNode
        {
            //Data
            public int Data { get; set; }
            //Key
            public string Key { get; private set; }
            //Constructor
            public HashNode(string key, int value)
            {
                Data = value;
                Key = key;
            }
        }
    }
}
