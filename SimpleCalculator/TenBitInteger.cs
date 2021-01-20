using System;
using System.Collections;

namespace SimpleCalculator
{
    public struct TenBitInteger
    {
        private BitArray Val;

        public TenBitInteger(int value)
        {
            Val = new BitArray(10);
            string result = Convert.ToString(value, 2);
            while (result.Length < 10) 
            {
                result = "0" + result;
            }
            for (int i = 0; i < 10; i++)
            {
                Val.Set(i, result[9-i] == '1');
            }
        }

        public static implicit operator TenBitInteger(int value)
        {
            return new TenBitInteger(value);
        }

        public static implicit operator int(TenBitInteger integer)
        {
            return BitsToInt(integer.Val);
        }

        public static TenBitInteger operator +(TenBitInteger first, TenBitInteger second)
        {
            int remainder = 0;
            var result = new BitArray(10);
            for (int i = 0; i < 10; i++) 
            {
                int firstBit = first.Val[i] ? 1 : 0;
                int secondBit = second.Val[i] ? 1 : 0;
                int currentBitValue = firstBit + secondBit + remainder;
                result.Set(i, currentBitValue % 2 == 1);
                remainder = currentBitValue > 1 ? 1 : 0;
            }
            return new TenBitInteger(BitsToInt(result));
        }

        public static TenBitInteger operator -(TenBitInteger first, TenBitInteger second)
        {
            int remainder = 0;
            var result = new BitArray(10);
            for (int i = 0; i < 10; i++)
            {
                int firstBit = first.Val[i] ? 1 : 0;
                int secondBit = second.Val[i] ? 1 : 0;
                int currentBitValue = firstBit - secondBit - remainder;
                result.Set(i, GetPositiveMod(currentBitValue) == 1);
                remainder = currentBitValue < 0 ? 1 : 0;
            }
            return new TenBitInteger(BitsToInt(result));
        }

        private static int GetPositiveMod(int number)
        {
            if (number >= 0)
                return number;
            else
                return number + 2;
        }

        private static int BitsToInt(BitArray bitArray)
        {
            int value = 0;

            for (int i = 0; i < 10; i++)
            {
                if (bitArray[i])
                    value += Convert.ToInt16(Math.Pow(2, i));
            }

            return value;
        }

        public int GetValue() 
        {
            return BitsToInt(Val);
        }
    }
}
