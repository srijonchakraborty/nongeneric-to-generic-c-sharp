using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericToGenericCSharpExample.NonGeneric
{
    internal class Service
    {
        public static void CallNonGenricClass()
        {
            var purchaseOrder = new PurchaseOrderModel
            {
                Id = 1,
                OrderNo = "PO123",
                OrderItems = new List<IOrderItemModel>
            {
                new PurchaseOrderItemModel
                {
                    Id = 1,
                    Name = "Product A",
                    Quantity = 2,
                    Price = 10.99m,
                    Discount = 1.0m
                },
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

            // Prepare and calculate the purchase order
            IOrderPrepare orderPrepare = new OrderPrepare();
            string itemDetails = orderPrepare.PrepareItemDetails(purchaseOrder.OrderItems);
            decimal totalPrice = orderPrepare.CalculatePrice(purchaseOrder);
        }
    }
}
