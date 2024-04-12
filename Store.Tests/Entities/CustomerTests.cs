using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ValidateName()
        {
            var customer = new Customer("Kaique", "kaique_rba@yahoo.com.br");

            Assert.IsTrue(customer.Valid);
        }
    }
}
