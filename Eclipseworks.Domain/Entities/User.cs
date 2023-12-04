using Eclipseworks.Domain.Entities.Common;

namespace Eclipseworks.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
