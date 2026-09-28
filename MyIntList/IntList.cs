using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyIntList
{
    internal class IntList
    {
        IntListElement firstElement { get; set; }
        private int Size = 0;
        public IntList()
        {
            
        }

        private void NewList()
        {

        }

        private IntListElement FindEnd()
        {
            IntListElement currentElement = firstElement;
            while (true)
            {
                if (currentElement.GetPointer() == null)
                {
                    return currentElement;
                }
                currentElement = currentElement.GetPointer();
            }
        }

        public IntListElement FindElement(int value)
        {
            var current = firstElement;
            while(current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }
                current = current.GetPointer();
            }
            Console.WriteLine($"Could not find {value}");
            return null;
        }

        public bool RemoveElement(int value)
        {
            var element = FindElement(value);
            if (element != null)
            {
                // Remove the element
                if (element.GetPointer() == null)
                {
                    element.RemovePointer();
                    Console.WriteLine("Removed");
                    return true;
                }

                var removedPointer = element.GetPointer();

                element.RemovePointer();
                Console.WriteLine("Removed");

                // Find new end
                var end = FindEnd();
                end.AddPointer(removedPointer);

                // temp return success
                return true;
            }
            // temp return fail
            return false;
        }

        public void AddElement(int value)
        {
            IntListElement newElement = new IntListElement(value, Size);
            if (Size > 0)
            {
                IntListElement currentElement = FindEnd();
                currentElement.AddPointer(newElement);
                Size += 1;
                return;
            }
            else
            {
                firstElement = new IntListElement(value, Size);
                Size += 1;
            }
        }

    }
}
