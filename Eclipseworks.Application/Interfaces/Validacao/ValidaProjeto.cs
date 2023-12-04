using Eclipseworks.Application.DTOs.Projeto.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Application.Interfaces.Validacao
{
    public class ValidaProjeto : AbstractValidator<CreateProjetoDto>
    {
        public ValidaProjeto()
        {
            RuleFor(x => x.Nome)
               .NotNull()
               .NotEmpty()
               .WithMessage("O nome do projeto deve ser preenchido.");

            RuleFor(x => x.Nome).Length(3, 50)
                .WithMessage("O nome deve ter entre 3 e 50 caracteres.");

            RuleFor(x => x.Descricao)
              .NotNull()
              .NotEmpty()
              .WithMessage("A descrição do projeto deve ser preenchida.");

            RuleFor(x => x.Descricao).Length(3, 100)
                .WithMessage("A descrição deve ter entre 3 e 100 caracteres.");

        }
    }
}
