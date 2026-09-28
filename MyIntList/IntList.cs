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

        /// Checks if input pointer matches any pointers in the list,
        /// returns the element containing the pointer or null if none are matching.
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

        /// Checks if input value matches any elements in the list,
        /// returns discovered element or null if none are matching
        private IntListElement? FindElement(int value)
        {
            var current = FirstElement;
            while(current != null)
            {
                if (current.Value == value)
                {
                    Console.WriteLine($"Value {value} found at position {current.Position}");
                    return current;
                }
                current = current.GetPointer();
            }
            return null;
        }
        

        /// Unlinks an element from the list with a given value, returns result
        public bool Remove(int value)
        {
            var element = FindElement(value);
            if (element != null)
            {
                if (element.Value == FirstElement.Value)
                {
                    FirstElement = FirstElement.GetPointer();
                    element.RemovePointer();
                    Size -= 1;
                    Console.WriteLine($"{value} has been removed from list. New list size: {Size}");
                    return true;
                }
                
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

        /// Checks if the given value matches any in the list, return result as a bool
        public bool Contains(int value)
        {
            if (FindElement(value) == null)
            {
                return false;
            }
            return true;
        }
        
        /// Creates a new element and appends it to the list
        public void Add(int value)
        {
            IntListElement newElement = new IntListElement(value, Size);
            
            
            if (Size > 0)
            {
                IntListElement currentElement = FindEnd();
                currentElement.AddPointer(newElement);
                Size += 1;
                Console.WriteLine($"{value} has been added to list. New list size: {Size}");
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
