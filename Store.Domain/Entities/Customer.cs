using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email)
        {
            AddNotifications( new Contract()
            .Requires()
            .IsNotNullOrEmpty(name, "Name", "O nome é obrigatório")
            .HasMinLen(name, 3, "Name", "O tamanho minino de nome é 3")
            .HasMaxLen(name, 30, "Name", "O tamanho máximo de nome é 100")
            .IsNotNullOrEmpty(email, "Email", "O email é obrigatório")
            .IsEmail(email, "Email", "Email inválido")
            );

            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}