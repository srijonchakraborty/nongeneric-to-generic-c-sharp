using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample.NonGeneric
{
    public interface IOrderPrepare
    {
        string PrepareItemDetails(List<IOrderItemModel> items);
        decimal CalculatePrice(IOrderModel order);
    }

    public class OrderPrepare : IOrderPrepare
    {
        public decimal CalculatePrice(IOrderModel order)
        {
            decimal price = 0;
            foreach (var item in order.OrderItems)
            {
                if (item is PurchaseOrderItemModel)
                {
                    price += (item.Price * item.Quantity) - ((PurchaseOrderItemModel)item).Discount;
                }
                if (item is SpotPurchaseOrderItemModel)
                {
                    price += (item.Price * item.Quantity);
                }
            }
            return price;
        }

        public string PrepareItemDetails(List<IOrderItemModel> OrderItems)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in OrderItems)
            {
                if (item is PurchaseOrderItemModel)
                { 
                    result.Append(@$"Name: {item.Name}, Discount: {((PurchaseOrderItemModel)item).Discount}");
                }
                if (item is SpotPurchaseOrderItemModel)
                {
                    result.Append(@$"Name: {item.Name}, Memo: {((SpotPurchaseOrderItemModel)item).MemoNumber}");
                }

           
            }
            return result.ToString();
        }
    }
}
