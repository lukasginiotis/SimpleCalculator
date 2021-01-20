using System;

namespace SimpleCalculator
{
    public class Calculator
    {
        private MemoryStack MemoryStack;

        public Calculator()
        {
            MemoryStack = new MemoryStack();
        }

        public void Push(TenBitInteger number)
        {
            MemoryStack.PushToMemory(number);
        }

        public void Pop()
        {
            MemoryStack.PopFromMemory();
        }

        public void Add()
        {
            if (MemoryStack.GetCount() < 2)
            {
                throw new Exception("Not enough operands in the stack.");
            }
            TenBitInteger first = MemoryStack.PopFromMemory();
            TenBitInteger second = MemoryStack.PopFromMemory();
            TenBitInteger result = first + second;
            Console.WriteLine(result.GetValue());
            MemoryStack.PushToMemory(result);
        }

        public void Sub()
        {
            if (MemoryStack.GetCount() < 2)
            {
                throw new Exception("Not enough operands in the stack.");
            }
            TenBitInteger first = MemoryStack.PopFromMemory();
            TenBitInteger second = MemoryStack.PopFromMemory();
            TenBitInteger result = first - second;
            Console.WriteLine(result.GetValue());
            MemoryStack.PushToMemory(result);
        }

        //For testing and debugging purposes
        public string GetCurrentStack() 
        {
            string result = "";
            MemoryStack tempStack = new MemoryStack();
            int stackSize = MemoryStack.GetCount();
            for (int i = 0; i < stackSize; i++)
            {
                TenBitInteger element = MemoryStack.PopFromMemory();
                result += element.GetValue() + ";";
                tempStack.PushToMemory(element);
            }
            for (int i = 0; i < stackSize; i++) 
            {
                MemoryStack.PushToMemory(tempStack.PopFromMemory());
            }
            return result;
        }
    }
}
