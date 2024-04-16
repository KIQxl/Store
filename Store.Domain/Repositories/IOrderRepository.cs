using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public void Save(Order order);
    }
}