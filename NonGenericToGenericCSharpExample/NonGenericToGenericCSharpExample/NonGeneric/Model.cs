using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample.NonGeneric
{
    public interface IOrderModel
    {
        int Id { get; set; }
        string OrderNo { get; set; }
        List<IOrderItemModel> OrderItems { get; set; }
    }
    public interface IOrderItemModel
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Quantity { get; set; }
        decimal Price { get; set; }
    }
    public class BaseOrderModel
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
    }
    public class BaseOrderItemModel : IOrderItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class PurchaseOrderModel : BaseOrderModel, IOrderModel
    {
        public List<IOrderItemModel> OrderItems { get; set; }
    }
    public class PurchaseOrderItemModel : BaseOrderItemModel
    {
        public decimal Discount { get; set; }
    }

    public class SpotPurchaseOrderModel : BaseOrderModel, IOrderModel
    {
        public List<IOrderItemModel> OrderItems { get; set; }
    }

    public class SpotPurchaseOrderItemModel : BaseOrderItemModel
    {
        public string MemoNumber { get; set; }
    }
}
