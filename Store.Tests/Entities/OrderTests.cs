using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void GenerateNumberWithHad8CaracteresWhenCreateNewOrder()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var product2 = new Product("Super mesa gamer", 100, true);
            var order = new Order(customer, 0, null);
            
            order.AddItem(product, 2);
            order.AddItem(product2, 1);

            Assert.IsTrue(order.Valid && order.Number.Length == 8);
        }

        [TestMethod]
        public void ReturnStatusWaitingDeliveryWhenPayOrder()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var product2 = new Product("Super mesa gamer", 100, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 2);
            order.AddItem(product2, 1);

            order.Pay(2100);

            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }

        [TestMethod]
        public void ReturnStatusWaitingPaymentWhenCreateNewOrder()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 2);

            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
        }

        [TestMethod]
        public void ReturnStatusCanceledWhenCanceledOrder()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var order = new Order(customer, 0, null);

            order.Cancel();

            Assert.AreEqual(EOrderStatus.Canceled, order.Status);
        }

        [TestMethod]
        public void ReturnTrueWhenAddItemInList()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 1);

            Assert.IsTrue(order.Items.Any());
        }


        [TestMethod]
        public void NoAddItemInListIfItemInvalid()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 0);
            order.AddItem(null, 2);

            Assert.IsTrue(!order.Items.Any());
        }

        [TestMethod]
        public void ReturnTheTotalOrderPrice()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 1);

            Assert.AreEqual(order.Total(), product.Price);
        }

        [TestMethod]
        public void ReturnFalseWhenDiscountInvalidBecauseExpireDate()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var discount = new Discount(100, DateTime.Now.AddMonths(-1));
            var order = new Order(customer, 0, discount); // deliveryFee = 0 - discount = 0

            order.AddItem(product, 1); //1000 * 1 = 1000

            Assert.AreEqual(order.Total(), 1000); // 1000 + 0 - 0 = 1000
        }

        [TestMethod]
        public void ReturnTrueWhenDiscountValid()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var discount = new Discount(100, DateTime.Now.AddMonths(1));
            var order = new Order(customer, 0, discount); // delivery = 0; discount = 100 

            order.AddItem(product, 1); // 1000 * 1 = 1000

            Assert.AreEqual(order.Total(), 900); // 1000 - 100 = 900
        }


        [TestMethod]
        public void ReturnTrueWhenDiscountInvalid()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var discount = new Discount(100, DateTime.Now.AddMonths(1));
            var order = new Order(customer, 0, null); // delivery = 0; discount = 0

            order.AddItem(product, 1); // 1000 * 1 = 1000

            Assert.AreEqual(order.Total(), 1000); // 1000 + 0 - 0 = 1000
        }

        [TestMethod]
        public void ReturnTrueWhenDeliveryFeeIsValid()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var discount = new Discount(100, DateTime.Now.AddMonths(1));
            var order = new Order(customer, 100, discount); //Delivery = 100 - discount = 100 = 0

            order.AddItem(product, 1); // 1000 * 1 = 1000

            Assert.AreEqual(order.Total(), 1000);
        }

        [TestMethod]
        public void ReturnTrueWhenDeliveryFeeIsInvalid()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var discount = new Discount(100, DateTime.Now.AddMonths(1));
            var order = new Order(customer, -100, discount);

            order.AddItem(product, 1);

            Assert.IsTrue(order.Invalid);
        }

        [TestMethod]
        public void ReturnTrueWhenCustomerNull()
        {
            var product = new Product("Pc gamer tunado", 1000, true);
            var discount = new Discount(100, DateTime.Now.AddMonths(1));
            var order = new Order(null , -100, discount);

            order.AddItem(product, 1);

            Assert.IsTrue(order.Invalid);
        }
    }
}