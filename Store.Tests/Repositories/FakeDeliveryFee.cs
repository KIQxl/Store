using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipCode)
        {
            if(zipCode == "08031450")
                return 10;

            return 20;
        }
    }
}