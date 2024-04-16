using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ReturnTrueWhenCustomerIsValid()
        {
            var customer = new Customer("Kaique", "kaique_rba@yahoo.com.br");

            Assert.IsTrue(customer.Valid);
        }

        [TestMethod]
        public void ReturnTrueWhenCustomerIsInvalid()
        {
            var customer = new Customer("K", "kaique_rba");

            Assert.IsTrue(customer.Invalid);
        }

        [TestMethod]
        public void ReturnTrueWhenCustomerNameIsInvalid()
        {
            var customer = new Customer("K", "kaique_rba@yahoo.com.br");

            Assert.IsTrue(customer.Invalid);
        }

        [TestMethod]
        public void ReturnTrueWhenCustomerNameIsValid()
        {
            var customer = new Customer("Kaique", "kaique_rba@yahoo.com.br");

            Assert.IsTrue(customer.Valid);
        }

        [TestMethod]
        public void ReturnTrueWhenCustomerEmailIsValid()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");

            Assert.IsTrue(customer.Valid);
        }

        [TestMethod]
        public void ReturnTrueWhenCustomerEmailIsInvalid()
        {
            var customer = new Customer("Kaique", "kaique");

            Assert.IsTrue(customer.Invalid);
        }
    }
}