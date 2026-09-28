using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyIntList
{
    internal class IntList
    {
        private IntListElement? FirstElement { get; set; } = null;
        private int Size = 0;

        private void NewList()
        {

        }

        private IntListElement FindEnd()
        {
            IntListElement? currentElement = FirstElement;
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
        private IntListElement? FindPrevious(IntListElement pointer)
        {
            var current = FirstElement;
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

        private IntListElement? FindElement(int value)
        {
            var current = FirstElement;
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
                if (element.Value == FirstElement.Value)
                {
                    FirstElement = FirstElement.GetPointer();
                    element.RemovePointer();
                    Size -= 1;
                    Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                    return true;
                }
                
                // If the item is last in the list
                if (element.GetPointer() == null)
                {
                    FindPrevious(element).RemovePointer();
                    Size -= 1;
                    Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                    return true;
                }

                var removedPointer = element.GetPointer();
                element.RemovePointer();
                
                var end = FindPrevious(element);
                end.AddPointer(removedPointer);
                
                Size -= 1;
                
                Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                return true;
            }
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
                FirstElement = new IntListElement(value, Size);
                Size += 1;
                Console.WriteLine($"{value} has been added to list. New list size: {Size}");
            }
        }
    }
}
