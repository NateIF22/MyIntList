using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyIntList
{
    internal class IntList
    {
        IntListElement firstElement { get; set; }
        public int Size = 0;
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

        // TODO: Think of a better name for this
        public IntListElement FindPointer(IntListElement pointer)
        {
            var current = firstElement;
            while (current != null)
            {
                if (current.GetPointer() == pointer)
                {
                    return current;
                }
                current = current.GetPointer();
            }
            return null;
        }

        public IntListElement FindElement(int value)
        {
            var current = firstElement;
            while(current != null)
            {
                if (current.Value == value)
                {
                    // Console.WriteLine($"Value {value} found at position {current.Position}");
                    return current;
                }
                current = current.GetPointer();
            }
            return null;
        }

        public bool RemoveElement(int value)
        {
            var element = FindElement(value);
            if (element != null)
            {
                // If the item is first in the list
                if (element.Value == firstElement.Value)
                {
                    firstElement = firstElement.GetPointer();
                    element.RemovePointer();
                    Size -= 1;
                    Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                    return true;
                }
                
                // If the item is last in the list
                if (element.GetPointer() == null)
                {
                    FindPointer(element).RemovePointer();
                    Size -= 1;
                    Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                    return true;
                }

                var removedPointer = element.GetPointer();

                
                // Currently only removes the pointer going from element to removedPointer,
                // Needs to change position of previous pointer as well
                element.RemovePointer();

                // Find old pointer
                var end = FindPointer(element);
                // override with new element
                end.AddPointer(removedPointer);
                Size -= 1;
                
                Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                
                // temp return success
                return true;
            }
            // temp return fail
            Console.WriteLine($"Couldn't find element: {value}");
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
                Console.WriteLine($"{value} has been added to list. New list size: {Size}");
                return;
            }
            else
            {
                firstElement = new IntListElement(value, Size);
                Size += 1;
                Console.WriteLine($"{value} has been added to list. New list size: {Size}");
            }
        }
    }
}
