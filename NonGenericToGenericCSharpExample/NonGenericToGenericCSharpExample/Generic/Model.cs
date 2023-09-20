using NonGenericToGenericCSharpExample.NonGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample.Generic
{
    public interface IOrderModel<TITemModel> where TITemModel : IOrderItemModel
    {
        int Id { get; set; }
        string OrderNo { get; set; }
        List<TITemModel> OrderItems { get; set; }
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
    public class PurchaseOrderModel : BaseOrderModel, IOrderModel<PurchaseOrderItemModel>
    {
        public List<PurchaseOrderItemModel> OrderItems { get; set; }
    }
    public class PurchaseOrderItemModel : BaseOrderItemModel
    {
        public decimal Discount { get; set; }
    }
    public class SpotPurchaseOrderModel : BaseOrderModel, IOrderModel<SpotPurchaseOrderItemModel>
    {
        public List<SpotPurchaseOrderItemModel> OrderItems { get; set; }
        
    }

    public class SpotPurchaseOrderItemModel : BaseOrderItemModel
    {
        public string MemoNumber { get; set; }
    }

}
