namespace Revision.DSAlg
{
    public class Stack
    {
        private DoubleLinkedList DoubleLinkedList { get; set; } = new DoubleLinkedList();
        public void Push(int Data)
        {
            DoubleLinkedList.Append(Data);
        }
        public void Pop()
        {
            DoubleLinkedList.GetData(DoubleLinkedList.Length);
            DoubleLinkedList.Remove(DoubleLinkedList.Length);
        }
    }
}
