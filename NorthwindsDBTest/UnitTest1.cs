using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthwindsDBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new NorthwindDB.NorthwindDB())
            {
                var result = from order in context.Orders
                             join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                             join product in context.Products on orderDetail.ProductID equals product.ProductID
                             where product.CategoryID == 1
                             select new
                             {
                                 ProductName = product.ProductName,
                                 UnitPrice = orderDetail.UnitPrice,
                                 Quantity = orderDetail.Quantity,
                                 Discount = orderDetail.Discount,
                                 CustomerName = order.Customer.ContactName,
                             };

                foreach (var item in result)
                {
                    Console.WriteLine($"Product name: {item.ProductName}; Unit price: {item.UnitPrice}; Quantity: {item.Quantity}; Discount: {item.Discount}; Contact name: {item.CustomerName}");
                }
               
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void EditCategoryThrowExceptionTest()
        {


            using (var context = new NorthwindDB.NorthwindDB())
            {
                var category = context.Categories.First(c => c.CategoryID == 1);
                category.CategoryName = "EditFirstUser";

                context.Entry(category).State = EntityState.Modified;
                ChangeFirstCategory();
                context.SaveChanges();
            }
        }

        private void ChangeFirstCategory()
        {
            using (var context = new NorthwindDB.NorthwindDB())
            {
                var category = context.Categories.First(c => c.CategoryID == 1);
                category.CategoryName = "EditSecondUser1";

                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
