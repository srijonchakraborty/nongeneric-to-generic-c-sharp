using NonGenericToGenericCSharpExample.NonGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample.Generic
{
    public interface IOrderPrepare<TModel,TItemModel> where TItemModel : IOrderItemModel
    {
        string PrepareItemDetails(List<TItemModel> items);
        decimal CalculatePrice(TModel order);
    }

    public class PurchaseOrderPrepare : IOrderPrepare<PurchaseOrderModel, PurchaseOrderItemModel>
    {
        public decimal CalculatePrice(PurchaseOrderModel order)
        {
            decimal price = 0;
            foreach (var item in order.OrderItems)
            {
                price += (item.Price * item.Quantity) - item.Discount;
            }
            return price;
        }

        public string PrepareItemDetails(List<PurchaseOrderItemModel> OrderItems)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in OrderItems)
            {
                result.Append(@$"Name: {item.Name}, Discount: {item.Discount}");

            }
            return result.ToString();
        }
    }

    public class SpotPurchaseOrderPrepare : IOrderPrepare<SpotPurchaseOrderModel, SpotPurchaseOrderItemModel>
    {
        public decimal CalculatePrice(SpotPurchaseOrderModel order)
        {
            decimal price = 0;
            foreach (var item in order.OrderItems)
            {
                price += (item.Price * item.Quantity);
            }
            return price;
        }

        public string PrepareItemDetails(List<SpotPurchaseOrderItemModel> OrderItems)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in OrderItems)
            {
                result.Append(@$"Name: {item.Name}, Memo: {item.MemoNumber}");

            }
            return result.ToString();
        }
    }
}
