using DataRepository;
using System;
using System.Linq;

namespace SumByCount
{
    public class PageSum
    {
        private readonly IOrderData _orderData;

        public PageSum()
        {

        }

        public PageSum(IOrderData order)
        {
            if (order == null) throw new NullReferenceException();
            this._orderData = order;
        }

        public int[] GetOrdersCostPageSum(int[] ids)
        {
            var tmp = _orderData.GetOrderCostData(ids);
            return SumByN(3, tmp);
        }

        public int[] GetOrdersRevenuePageSum(int[] ids)
        {
            return SumByN(4, _orderData.GetOrderRevenueData(ids));
        }

        private int[] SumByN(int n, params int[] numbers)
        {
            int numbersIndex = 0;
            int resultIndex = 0;
            int sum = 0;
            int[] result = new int[GetArraySize(n, numbers.Count())];

            foreach (var item in numbers)
            {
                sum = checked((int)((long)sum + (long)numbers[numbersIndex]));
                if (numbersIndex % n == n - 1 || numbersIndex == numbers.Count() - 1)
                {
                    result[resultIndex] = sum;
                    resultIndex++;
                    sum = 0;
                }
                numbersIndex++;
            }

            return result;
        }

        private int GetArraySize(int n, int c)
        {
            int result = 0;
            if (c % n == 0)
            { result = c / n; }
            else
            { result = (c / n) + 1; }
            return result;
        }
    }
}
