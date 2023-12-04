using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Commands;
using FluentValidation;

namespace Eclipseworks.Application.Interfaces.Validacao
{
    public class ValidaAtualizacaoDeTarefa : AbstractValidator<UpdateTarefaDto>
    {
        public ValidaAtualizacaoDeTarefa()
        {
            RuleFor(x => x.Titulo)
               .NotNull()
               .NotEmpty()
               .WithMessage("O título da tarefa deve ser preenchido.");

            RuleFor(x => x.Titulo).Length(3, 50)
                .WithMessage("O título deve ter entre 3 e 50 caracteres.");

            RuleFor(x => x.Descricao)
              .NotNull()
              .NotEmpty()
              .WithMessage("A descrição da tarefa deve ser preenchida.");

            RuleFor(x => x.DataVencimento).GreaterThan(DateTimeOffset.Now.Date)
               .WithMessage("A data de vencimento deve ser válida.");

            RuleFor(x => x.Status)
              .InclusiveBetween(0, 3)
              .WithMessage("O status deve ser 0 = pendente, 1 = em Andamento ou 2 = concluída");


        }
    }
}
