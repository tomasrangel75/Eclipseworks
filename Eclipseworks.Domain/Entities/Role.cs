namespace Eclipseworks.Domain.Entities
{
    public sealed class Role
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string?  Descricao{ get; set; }

        public List<UserRole>? UserRoles { get; set; }
    }
}
