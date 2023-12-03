using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Services.Services
{
    public class TarefaService : ITarefaService
    {
        #region commands

        public Task<Result<int>> AtualizarTarefa(UpdateTarefaDto command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> CriarTarefa(CreateTarefaDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> ExcluirTarefa(DeleteTarefaDto command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region queries

        public Task<Result<TarefaResponseDto>> ConsultarTarefa(TarefaFilterRequestDto query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        //public async Task<Result<int>> AtualizarProjeto(UpdateProjetoDto command, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var projeto = await _unitOfWork.Repository<Projeto>().GetByIdAsync(command.Id);
        //        if (projeto != null)
        //        {
        //            projeto.Nome = command.Nome;
        //            projeto.Descricao = command.Descricao;
        //            projeto.Status = command.Status;

        //            await _unitOfWork.Repository<Projeto>().UpdateAsync(projeto);

        //            await _unitOfWork.Save(cancellationToken);

        //            return await Result<int>.SuccessAsync(projeto.Id, "Projeto atualizado.");
        //        }
        //        else
        //        {
        //            return await Result<int>.FailureAsync("Projeto não encontrado.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Result<int>.FailureAsync(ex);
        //    }

        //}
    }
}
