namespace Lab3
{
    public class StockExchangeCheater
    {
        private int[] _prices;

        public StockExchangeCheater(uint[] prices)
        {
            _prices = new int[prices.Length];

            for (var i = 0; i < prices.Length; ++i)
                _prices[i] = (int) prices[i];
        }

        public (int buyDayIndex, int sellDayIndex, int profit) DoTimeWarpCheating()
        {
            var differences = new int[_prices.Length - 1];

            for (var i = 0; i < differences.Length; ++i)
                differences[i] = _prices[i + 1] - _prices[i];

            
            


            return (0, 0, 0);
        }
    }
}