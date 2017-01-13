using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumByCount;
using System.Collections.Generic;
using System.Linq;

namespace SumByCountTest
{
    [TestClass]
    public class PageSumTest
    {
        private List<Order> _orders = new List<Order>(){
                new Order { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Order { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Order { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new Order { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new Order { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Order { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new Order { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Order { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new Order { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new Order { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Order { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
            };

        [TestMethod]
        public void SumByN_傳入一組Cost_3筆一組總合應為_6_15_24_21()
        {
            //arrange
            PageSum target = new PageSum();
            int[] ordersCost = _orders.Select(o => o.Cost).ToArray();
            int[] expected = new int[] { 6, 15, 24, 21 };

            //act
            var actual = target.SumByN(3, ordersCost);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void SumByN_傳入一組Revenue_4筆一組總合應為_50_66_60()
        {
            //arrange
            PageSum target = new PageSum();
            int[] ordersRevenue = _orders.Select(o => o.Revenue).ToArray();
            int[] expected = new int[] { 50, 66, 60 };

            //act
            var actual = target.SumByN(4, ordersRevenue);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }

    internal class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }
}
