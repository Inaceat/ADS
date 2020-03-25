using System;

namespace Lab3
{
    public class StockExchangeCheater
    {
        private readonly int[] _prices;

        private int[] _differences;


        public StockExchangeCheater(uint[] prices)
        {
            if (null == prices)
                throw new ArgumentNullException();

            
            _prices = new int[prices.Length];
            
            for (var i = 0; i < prices.Length; ++i)
                _prices[i] = (int) prices[i];
        }

        public (int buyDayIndex, int sellDayIndex, int profit) DoTimeWarpCheating()
        {
            if (_prices.Length < 2)
                return (0, 0, 0);


            _differences = new int[_prices.Length - 1];

            for (var i = 0; i < _differences.Length; ++i)
                _differences[i] = _prices[i + 1] - _prices[i];

            
            (int buyDayIndex, int sellDayIndex, _) = GetMaxSumSubarray(0, _differences.Length);


            return (buyDayIndex, sellDayIndex, _prices[sellDayIndex] - _prices[buyDayIndex]);
        }


        private (int subBeginIndex, int subAfterEndIndex, int maxSum) GetMaxSumSubarray(int firstIndex, int afterLastIndex)
        {
            //If array has only 1 element, it's obviously max sum
            if (1 == afterLastIndex - firstIndex)
                return (firstIndex, afterLastIndex, _differences[firstIndex]);

            //Now array has at least 2 elements
            //So, divide it
            int afterMidIndex = (afterLastIndex - firstIndex) / 2;

            //Some recursive calls
            var left = GetMaxSumSubarray(firstIndex, afterMidIndex);
            var right = GetMaxSumSubarray(afterMidIndex, afterLastIndex);

            //Now
            //Find max sum subarray of left part, [?, afterMid)
            var leftPartMaxSum = int.MinValue;
            var leftPartMaxSumBeginIndex = afterMidIndex - 1;

            var currentSum = 0;

            for (var i = afterMidIndex - 1; i >= 0; --i)
            {
                currentSum += _differences[i];

                if (currentSum >= leftPartMaxSum)
                {
                    leftPartMaxSum = currentSum;
                    leftPartMaxSumBeginIndex = i;
                }
            }

            //Find max sum subarray of right part, [afterMid, ?)
            var rightPartMaxSum = int.MinValue;
            var rightPartMaxSumAfterEndIndex = afterMidIndex + 1;

            currentSum = 0;

            for (var i = afterMidIndex; i < afterLastIndex; ++i)
            {
                currentSum += _differences[i];

                if (currentSum > rightPartMaxSum)
                {
                    rightPartMaxSum = currentSum;
                    rightPartMaxSumAfterEndIndex = i + 1;
                }
            }

            //Now get parts together
            var mid = (leftPartMaxSumBeginIndex, rightPartMaxSumAfterEndIndex, leftPartMaxSum + rightPartMaxSum);

            //Compare left, right and mid
            if (left.maxSum < mid.Item3)
            {
                if (mid.Item3 < right.maxSum)
                    return right;
                else
                    return mid;
            }
            else
            {
                if (left.maxSum < right.maxSum)
                    return right;
                else
                    return left;
            }
        }
    }
}