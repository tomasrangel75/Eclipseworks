using AutoMapper;
using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;
using Eclipseworks.Shared;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Services.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjetoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region commands

        public async Task<Result<int>> CriarProjeto(CreateProjetoDto command, CancellationToken cancellationToken)
        {
            try
            {
                var projeto = new Projeto {
                    Nome = command.Nome?.Trim(), 
                    Descricao = command.Descricao, 
                    Status =  StatusProjetoEnum.ativo,
                    CriadoPor = command.UserId,
                    DataCriacao = DateTimeOffset.Now};

                projeto = await _unitOfWork.Repository<Projeto>().AddAsync(projeto);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(projeto.Id, "Projeto criado com sucesso.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }
                
        public async Task<Result<int>> ExcluirProjeto(DeleteProjetoDto command, CancellationToken cancellationToken)
        {
            try
            {
                var projeto = await _unitOfWork.Repository<Projeto>().GetByIdAsync(command.Id);

                if (projeto != null)
                {
                    var tarefasPendentes = projeto.Tarefas?.Where(x => x.Status == StatusTarefaEnum.pendente)?.OrderBy(p => p.Id);

                    if (tarefasPendentes != null && tarefasPendentes.Any())
                    {
                        var mensagemTarefasPendentes =
                            tarefasPendentes.Select(item => $"A tarefa de ID {item.Id} está pendente. Conclua ou remova a tarefa primeiro").ToList();

                        return await Result<int>.FailureAsync(mensagemTarefasPendentes);
                    }

                    await _unitOfWork.Repository<Projeto>().DeleteAsync(projeto);

                    await _unitOfWork.Save(cancellationToken);

                    return await Result<int>.SuccessAsync(projeto.Id, "Projeto excluído com sucesso.");
                }
                else
                {
                    return await Result<int>.FailureAsync("Projeto não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }

        }

        #endregion

        #region queries

        public async Task<Result<ProjetoResponseDtoList>> ConsultarProjeto(ProjetoFilterRequestDto query, CancellationToken cancellationToken)
        {
            var projetos = 
                await _unitOfWork.Repository<Projeto>().Entities
                .Where(p => p.CriadoPor == query.UserId).OrderBy(p => p.Id)
                .ToListAsync(cancellationToken: cancellationToken);

            var result = new ProjetoResponseDtoList { 
                ProjetoResponseDtos = _mapper.Map<ICollection<ProjetoResponseDto>>(projetos)?.ToList()};
            
            return await Result<ProjetoResponseDtoList>.SuccessAsync(result);
        }

        #endregion
    }
}
