using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumByCount;
using System.Linq;

namespace SumByCountTest
{
    [TestClass]
    public class PageSumTest
    {
        [TestMethod]
        public void SumByN_傳入一組Cost_3筆一組總合應為_6_15_24_21()
        {
            //arrange
            PageSum target = new PageSum();
            int[] ordersCost = Enumerable.Range(1, 11).ToArray();
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
            int[] ordersRevenue = Enumerable.Range(11, 11).ToArray();
            int[] expected = new int[] { 50, 66, 60 };

            //act
            var actual = target.SumByN(4, ordersRevenue);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}
