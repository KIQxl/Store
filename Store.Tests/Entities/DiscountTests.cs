using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class DiscountTests
    {
        [TestMethod]
        public void ReturnTrueWhenDiscountIsValid()
        {
            var discount = new Discount(100, DateTime.Now.AddMonths(2));

            Assert.IsTrue(discount.Valid);
        }

        [TestMethod]
        public void ReturnTrueWhenDiscountIsInvalidBecauseNegativeAmountValue()
        {
            var discount = new Discount(-100, DateTime.Now.AddMonths(2));
            
            Assert.IsTrue(discount.Invalid);
        }
    }
}