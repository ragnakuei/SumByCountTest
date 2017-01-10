using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public interface IOrderData
    {
        int[] GetOrderCostData(int[] ids);
        int[] GetOrderRevenueData(int[] ids);
        int[] GetPropertyArray(string propertyName,int[] ids);
    }
}
