using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {   
        private IList<Product> _products;
        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto 01", 10, true));
            _products.Add(new Product("Produto 02", 20, true));
            _products.Add(new Product("Produto 03", 30, true));
            _products.Add(new Product("Produto 04", 40, true));
            _products.Add(new Product("Produto 05", 50, false));
            _products.Add(new Product("Produto 06", 60, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Returns4WhenConsultingTheNumberOfActiveProducts()
        {
            var results = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());

            Assert.AreEqual(results.Count(), 4);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Returns2WhenConsultingTheNumberOfInactiveProducts()
        {
            var results = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());

            Assert.AreEqual(results.Count(), 2);
        }
    }
}