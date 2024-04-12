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
        public void Dado_um_novo_pedido_valido_deve_gerar_um_numero_com_8_caracteres()
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
        public void Dado_um_pagamento_deve_alterar_o_status_para_aguardando_delivery()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var product2 = new Product("Super mesa gamer", 100, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 2);
            order.AddItem(product2, 1);

            order.Pay(order.Total());

            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }

        public void Dado_um_novo_pedido_deve_o_status_deve_ser_aguadando_pagamento()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var product2 = new Product("Super mesa gamer", 100, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 2);

            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
        }

        [TestMethod]
        public void Dado_um_pedido_com_um_item_invalido_nao_deve_ser_adicionado_na_lista()
        {
            var customer = new Customer("Kaique", "kaique@yahoo.com.br");
            var product = new Product("Pc gamer tunado", 1000, true);
            var product2 = new Product("Super mesa gamer", 100, true);
            var order = new Order(customer, 0, null);

            order.AddItem(product, 0);
            order.AddItem(product2, 1);

            Assert.AreEqual(order.Total(), 100);
        }
    }
}