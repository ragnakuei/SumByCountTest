using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpectedObjects;
using SumByCount;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace SumByCountTest
{
    [TestClass]
    public class PageSumTest
    {
        private static List<Order> _orderData;
        private static PageSum _target;

        [ClassInitialize()]
        public static void InitialOrderData(TestContext testContext)
        {
            _orderData = new List<Order>(){
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

            _target = new PageSum();
        }

        [TestMethod]
        public void SumByN_3筆一組的Cost總和()
        {
            //arrange
            int[] expected = new int[] { 6, 15, 24, 21 };

            //act
            int[] data = _orderData.Select(o => o.Cost).ToArray();
            var actual = _target.SumByN(3, data);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void SumByN_4筆一組的Revenue總和()
        {
            //arrange
            int[] expected = new int[] { 50, 66, 60 };

            //act
            int[] data = _orderData.Select(o => o.Revenue).ToArray();
            var actual = _target.SumByN(4, data);

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
