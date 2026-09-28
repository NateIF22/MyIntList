namespace MyIntList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an int list element with a value and pointer, the pointer is empty right now
            // create a new element with a value and no pointer
            // Add the second item to the first item's pointer
            List<int> testList = new List<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(2);
            testList.Add(2);

            testList.Remove(2);

            Console.WriteLine(testList.Count);
            foreach (int i in testList)
            {
                Console.WriteLine(i);
            }

            IntList intList = new IntList();
            intList.AddElement(20);
            intList.AddElement(15);
            intList.AddElement(2);
            intList.AddElement(2000);
            intList.AddElement(95);
            intList.AddElement(9);
            intList.FindElement(2);
            intList.RemoveElement(2);
            intList.FindElement(2);
            intList.FindElement(9);
        }
    }
}
