using Eclipseworks.Domain.Entities.Common;

namespace Eclipseworks.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }

        public string Nome { get; set; }
        public string?  Descricao{ get; set; }

        public List<UserRole>? UserRoles { get; set; }
    }
}
