using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, DateTime expireDate)
        {
            AddNotifications( new Contract()
            .Requires()
            .IsNotNull(amount, "amount", "O valor de desconto é obrigatório")
            .IsNotNull(expireDate, "expireDate", "A data de vencimento do desconto é obrigatória")
            .IsGreaterThan(amount, 0, "amount", "O valor do desconto deve ser maior que 0")
            );

            Amount = amount;
            ExpireDate = expireDate;
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public bool IsValid()
        {
            return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
        }

        public decimal Value()
        {
            if(IsValid())
            {
                return Amount;
            }

            return 0;
        }
    }
}