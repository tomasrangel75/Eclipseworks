namespace Eclipseworks.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
