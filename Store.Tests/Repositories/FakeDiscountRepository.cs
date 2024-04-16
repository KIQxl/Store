using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code == "promo10")
                return new Discount(10, DateTime.Now.AddMonths(1));

             if (code == "promofail")
                return new Discount(10, DateTime.Now.AddMonths(-1));
            
            return null;
        }
    }
}