using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class MemoryStack
    {
        private Stack<TenBitInteger> Memory;
        public MemoryStack()
        {
            Memory = new Stack<TenBitInteger>();
        }

        public void PushToMemory(TenBitInteger newValue)
        {
            if (Memory.Count >= 5)
            {
                throw new Exception("The calculator is out of memory.");
            }
            Memory.Push(newValue);
        }

        public TenBitInteger PopFromMemory()
        {
            if (Memory.Count > 0)
                return Memory.Pop();
            else
                return -1;
        }

        public void PrintOut()
        {
            foreach (int value in Memory)
            {
                Console.WriteLine(value);
            }
        }

        public int GetCount()
        {
            return Memory.Count;
        }
    }
}
