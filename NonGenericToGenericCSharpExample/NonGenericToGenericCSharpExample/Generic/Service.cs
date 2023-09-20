using NonGenericToGenericCSharpExample.NonGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample.Generic
{
    internal class Service
    {
        public static void CallGenricClass()
        {
            var purchaseOrder = new PurchaseOrderModel
            {
                Id = 1,
                OrderNo = "PO123",
                OrderItems = new List<PurchaseOrderItemModel>
            {
                new PurchaseOrderItemModel
                {
                    Id = 1,
                    Name = "Product A",
                    Quantity = 2,
                    Price = 10.99m,
                    Discount = 1.0m
                },
            }
            };

            IOrderPrepare<PurchaseOrderModel, PurchaseOrderItemModel> orderPrepare = new PurchaseOrderPrepare();
            string itemDetails = orderPrepare.PrepareItemDetails(purchaseOrder.OrderItems);
            decimal totalPrice = orderPrepare.CalculatePrice(purchaseOrder);


            var SpotpurchaseOrder = new SpotPurchaseOrderModel
            {
                Id = 1,
                OrderNo = "SPO123",
                OrderItems = new List<SpotPurchaseOrderItemModel>
            {

                new SpotPurchaseOrderItemModel
                {
                    Id = 2,
                    Name = "Product B",
                    Quantity = 3,
                    Price = 15.99m,
                    MemoNumber = "Memo123"
                }
            }
            };

            IOrderPrepare<SpotPurchaseOrderModel, SpotPurchaseOrderItemModel> spotorderPrepare = new SpotPurchaseOrderPrepare();
            string itemDetailsspot = spotorderPrepare.PrepareItemDetails(SpotpurchaseOrder.OrderItems);
            decimal totalPricespot = spotorderPrepare.CalculatePrice(SpotpurchaseOrder);
        }
    }
}
