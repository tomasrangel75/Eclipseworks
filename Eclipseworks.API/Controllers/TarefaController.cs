using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TarefaController : ApiControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;

        }

        [HttpGet("ConsultarTarefaPorProjeto/{id}")]
        public async Task<ActionResult<Result<TarefaResponseDtoList>>> ConsultarTarefaPorProjeto(int id)
        {
            var filtro = new TarefaFilterRequestDto() { ProjetoId = id };
            return await _tarefaService.ConsultarTarefa(filtro);
        }

        [HttpPost("CadastrarTarefa")]
        public async Task<ActionResult<Result<int>>> CriarTarefa([FromBody] CreateTarefaDto command)
        {
            return await _tarefaService.CriarTarefa(command);
        }

        [HttpPut("AtualizarTarefa/{id}")]
        public async Task<ActionResult<Result<int>>> AtualizarTarefa(int id, [FromBody] UpdateTarefaDto command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _tarefaService.AtualizarTarefa(command);
        }

        [HttpDelete("ExcluirTarefa/{id}")]
        public async Task<ActionResult<Result<int>>> ExcluirTarefa(int id)
        {
            var deleteTarefaDto = new DeleteTarefaDto() { Id = id};

            return await _tarefaService.ExcluirTarefa(deleteTarefaDto); ;
        }
    }
}
