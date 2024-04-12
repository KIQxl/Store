using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, bool active)
        {
            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "O titulo é obrigatório")
                .IsGreaterThan(price, 0, "Price", "O preço do produto é obrigatório")
            );

            Title = title;
            Price = price;
            Active = active;
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}