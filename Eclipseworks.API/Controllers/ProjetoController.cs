using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Eclipseworks.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProjetoController : ApiControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;

        }

        [HttpGet("ConsultarProjetoPorUsuario/{id}")]
        public async Task<ActionResult<Result<ProjetoResponseDtoList>>> ConsultarProjetoPorUsuario(int id)
        {
            var filtro = new ProjetoFilterRequestDto() { UserId = id };

            return await _projetoService.ConsultarProjeto(filtro);
        }

        [HttpPost("CadastrarProjeto")]
        public async Task<ActionResult<Result<int>>> CriarProjeto([FromBody] CreateProjetoDto command)
        {
           return await _projetoService.CriarProjeto(command);
        }

        [HttpDelete("ExcluirProjeto/{id}")]
        public async Task<ActionResult<Result<int>>> ExcluirProjeto(int id)
        {
            var deleteProjetoDto = new DeleteProjetoDto() { Id = id };

            return await _projetoService.ExcluirProjeto(deleteProjetoDto); ;
        }
    }
}
