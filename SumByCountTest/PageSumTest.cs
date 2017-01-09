using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpectedObjects;
using SumByCount;
using FluentAssertions;
using NSubstitute;
using DataRepository;

namespace SumByCountTest
{
    [TestClass]
    public class PageSumTest
    {

        [TestMethod]
        public void 測試未注入資料_要產生例外()
        {
            // arrange
            PageSum target = new PageSum();
            int[] ids = { 1, 2, 3, 4, 5 };

            // act
            Action act = () => target.GetOrdersCostPageSum(ids);

            // assert
            act.ShouldThrow<NullReferenceException>();
        }

        [TestMethod]
        public void 取得OrderCostPageSum_1個數()
        {
            // 為何 GetOrdersCostPageSum() 與 Substitute() 接收的不同 Array
            // 就會判定為不同的東西，導致無法取得想要的回傳值
            // 待確認:是否為 reference type 的關係

            // arrange
            int[] intArray = new int[] { 1 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderCostData(intArray).Returns(new int[] { 1 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 1 };

            // act
            var actual = target.GetOrdersCostPageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderCostPageSum_2個數()
        {
            // arrange
            int[] intArray = new int[] { 1, 2 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderCostData(intArray).Returns(new int[] { 1, 2 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 3 };

            // act
            var actual = target.GetOrdersCostPageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderCostPageSum_3個數()
        {
            // arrange
            int[] intArray = new int[] { 1, 2, 3 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderCostData(intArray).Returns(new int[] { 1, 2, 3 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 6 };

            // act
            var actual = target.GetOrdersCostPageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderCostPageSum_4個數()
        {
            // arrange
            int[] intArray = new int[] { 1, 2, 3, 4 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderCostData(intArray).Returns(new int[] { 1, 2, 3, 4 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 6, 4 };

            // act
            var actual = target.GetOrdersCostPageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderCostPageSum_int上限例外()
        {
            // arrange
            int[] intArray = new int[] { int.MaxValue, 2, 3, 4, 5 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderCostData(intArray).Returns(new int[] { int.MaxValue, 2, 3, 4, 5 });

            PageSum target = new PageSum(orderData);

            // act
            Action act = () => target.GetOrdersCostPageSum(intArray);

            // assert
            act.ShouldThrow<OverflowException>();
        }

        [TestMethod]
        public void 取得OrderCostPageSum_int下限例外()
        {
            // arrangea
            int[] intArray = new int[] { int.MinValue, -1 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderCostData(intArray).Returns(new int[] { int.MinValue, -1 });

            PageSum target = new PageSum(orderData);

            // act
            Action act = () => target.GetOrdersCostPageSum(intArray);

            // assert
            act.ShouldThrow<OverflowException>();
        }

        [TestMethod]
        public void 取得OrderRevenuePageSum_3個數()
        {
            // arrange
            int[] intArray = new int[] { 4, 5, 6 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderRevenueData(intArray).Returns(new int[] { 14, 15, 16 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 45 };

            // act
            var actual = target.GetOrdersRevenuePageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderRevenuePageSum_4個數()
        {
            // arrange
            int[] intArray = new int[] { 5, 6, 7, 8 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderRevenueData(intArray).Returns(new int[] { 15, 16, 17, 18 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 66 };

            // act
            var actual = target.GetOrdersRevenuePageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderRevenuePageSum_5個數()
        {
            // arrange
            int[] intArray = new int[] { 7, 8, 9, 10, 11 };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderRevenueData(intArray).Returns(new int[] { 17, 18, 19, 20, 21 });

            PageSum target = new PageSum(orderData);
            int[] expected = { 74, 21 };

            // act
            var actual = target.GetOrdersRevenuePageSum(intArray);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void 取得OrderRevenuePageSum_int上限例外()
        {
            // arrange
            int[] intArray = new int[] { 5, 6, 7, int.MaxValue };
            var orderData = Substitute.For<IOrderData>();
            orderData.GetOrderRevenueData(intArray).Returns(new int[] { 15, 16, 17, int.MaxValue });

            PageSum target = new PageSum(orderData);

            // act
            Action act = () => target.GetOrdersRevenuePageSum(intArray);

            // assert
            act.ShouldThrow<OverflowException>();
        }
    }
}
