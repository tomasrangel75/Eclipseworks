using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Commands;
using FluentValidation;

namespace Eclipseworks.Application.Interfaces.Validacao
{
    public class ValidaCriacaoDeTarefa : AbstractValidator<CreateTarefaDto>
    {
        public ValidaCriacaoDeTarefa()
        {
            RuleFor(x => x.Titulo)
               .NotNull().WithMessage("O título da tarefa não pode ser nulo.")
               .NotEmpty().WithMessage("O título da tarefa deve ser preenchido.");

            RuleFor(x => x.Titulo).Length(3, 50)
                .WithMessage("O título deve ter entre 3 e 50 caracteres.");

            RuleFor(x => x.Descricao)
              .NotNull().WithMessage("A descrição da tarefa não pode ser nula.")
              .NotEmpty().WithMessage("A descrição da tarefa deve ser preenchida.");

            RuleFor(x => x.Prioridade)
               .InclusiveBetween(0,3)
               .WithMessage("A prioridade deve ser 0 = baixa, 1 = média ou 2 = alta");

            RuleFor(x => x.DataVencimento).GreaterThan(DateTimeOffset.Now.Date)
               .WithMessage("A data de vencimento deve ser válida.");

           

        }
    }
}
