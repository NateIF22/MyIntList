namespace MyIntList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IntList intList = new IntList();
            intList.Add(918023);
            intList.Add(20);
            intList.Add(2);
            intList.Add(2000);

            if (intList.Contains(918023))
            {
                Console.WriteLine("Contains 918023");
            }
            
            intList.Remove(2);
            intList.Remove(15);
            intList.Remove(2000);
            intList.Remove(20);
        }
    }
}
