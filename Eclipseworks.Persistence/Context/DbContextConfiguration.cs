using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Common;
using Eclipseworks.Persistence.Context.Builders;
using Eclipseworks.Persistence.Context.Seed;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        public virtual DbSet<TarefaHistorico> TarefaHistoricos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(new UserConfiguration().Configure);
            modelBuilder.Entity<Role>(new RoleConfiguration().Configure);
            modelBuilder.Entity<UserRole>(new UserRoleConfiguration().Configure);
  
            modelBuilder.Entity<Projeto>(new ProjetoConfiguration().Configure);
            modelBuilder.Entity<Tarefa>(new TarefaConfiguration().Configure);
            modelBuilder.Entity<TarefaHistorico>(new TarefaHistoricoConfiguration().Configure);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
       
    }
}
