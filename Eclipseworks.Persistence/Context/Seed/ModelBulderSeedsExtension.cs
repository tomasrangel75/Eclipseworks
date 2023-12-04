using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Eclipseworks.Persistence.Context.Seed
{

    [ExcludeFromCodeCoverage]
    public static class ModelBulderSeedsExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            List<User> listUsers = new List<User>()
            {
                new User(){Id = 1, Nome = "Admin", Sobrenome = "", CriadoPor = 1, DataCriacao = DateTimeOffset.Now },
                new User(){Id = 2, Nome = "User1", Sobrenome = "", CriadoPor = 1, DataCriacao = DateTimeOffset.Now },
                new User(){Id = 3, Nome = "User2", Sobrenome = "", CriadoPor = 1, DataCriacao = DateTimeOffset.Now }
            };

            modelBuilder.SetDataToEntity<User>(listUsers);
        }
        
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            List<Role> roles = new List<Role>()
            {
                new Role(){Id = 1, Nome = "Admin", Descricao = "Usuario com permissões administrativas"},
                new Role(){Id = 2, Nome = "Basico", Descricao = "Usuario com permissões básicas"},
                new Role(){Id = 3, Nome = "Gerente", Descricao = "Usuario com permissões nível gerencial"}
            };

            modelBuilder.SetDataToEntity<Role>(roles);
        }

        public static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            List<UserRole> userRoles = new List<UserRole>()
            {
                new UserRole(){Id = 1,  RoleId = 1, UserId =1},
                new UserRole(){Id = 2,  RoleId = 2, UserId =1},
                new UserRole(){Id = 3, RoleId = 2, UserId =2},
                new UserRole(){Id = 4, RoleId = 3, UserId =3},
                new UserRole(){Id = 5,  RoleId = 2, UserId =3},
            };

            modelBuilder.SetDataToEntity<UserRole>(userRoles);
        }

        private static void SetDataToEntity<T>(this ModelBuilder modelBuilder, List<T> data) where T : BaseEntity
        {
            modelBuilder.Entity<T>().HasData(data);
        }
    }
}