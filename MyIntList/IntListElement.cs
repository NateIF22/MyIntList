using System;
using System.Collections.Generic;
using System.Text;

namespace MyIntList
{
    public class IntListElement
    {
        public int Value { get; set; }
        public int Position { get; set; }
        private IntListElement? Pointer { get; set; } = null;
        public IntListElement(int value, int position)
        {
            Value = value;
            Position = position;
        }

        public void RemovePointer()
        {
            Pointer = null;
        }

        public void AddPointer(IntListElement pointer)
        {
            Pointer = pointer;
        }

        public IntListElement? GetPointer()
        {
            return Pointer;
        }
    }
}
