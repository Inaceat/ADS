using System;

namespace Lab3
{
    public class StockExchangeCheater
    {
        private readonly int[] _prices;

        private readonly int[] _differences;

        public StockExchangeCheater(uint[] prices)
        {
            if (null == prices)
                throw new ArgumentNullException();



            _prices = new int[prices.Length];
            
            for (var i = 0; i < prices.Length; ++i)
                _prices[i] = (int) prices[i];


            //To one cycle?
            _differences = new int[prices.Length - 1];

            for (var i = 0; i < prices.Length - 1; ++i)
                _differences[i] = _prices[i + 1] - _prices[i];   
        }

        public (int buyDayIndex, int sellDayIndex, int profit) DoTimeWarpCheating()
        {
            (int buyDayIndex, int sellDayIndex) = GetMaxSumSubarray(0, _differences.Length - 1);
            ++sellDayIndex;

            return (buyDayIndex, sellDayIndex, _prices[sellDayIndex] - _prices[buyDayIndex]);
        }


        private (int subBeginIndex, int subEndIndex) GetMaxSumSubarray(int arrayBeginIndex, int arrayEndIndex)
        {
            if (arrayBeginIndex == arrayEndIndex)
                return (arrayBeginIndex, arrayEndIndex);

            int afterMidIndex = (arrayEndIndex - arrayBeginIndex + 1) / 2;

            

            return (0, 0);
        }
    }
}