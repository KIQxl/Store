using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        public void ReturnFalseWhenInvalidCommand()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "08031450";
            command.PromoCode = "promo10";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }
    }
}