using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Interfaces.Services
{
    public interface IProjetoService
    {
        Task<Result<int>> CriarProjeto(CreateProjetoDto request);
        Task<Result<int>> ExcluirProjeto(DeleteProjetoDto command);
        Task<Result<ProjetoResponseDtoList>> ConsultarProjeto(ProjetoFilterRequestDto query);
    }


}
