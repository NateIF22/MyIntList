namespace MyIntList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IntList intList = new IntList();
            intList.AddElement(20);
            intList.AddElement(2);
            intList.AddElement(2000);
            
            intList.RemoveElement(2);
            intList.RemoveElement(15);
            intList.RemoveElement(2000);
            intList.RemoveElement(20);
        }
    }
}
