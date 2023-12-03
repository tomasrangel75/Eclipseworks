using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ApiControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;

        }

        [ProducesResponseType(typeof(Result<ProjetoResponseDtoList>), 200)]

        [HttpGet("ConsultarProjeto")]
        public async Task<IActionResult> ConsultarProjeto([FromBody] ProjetoFilterRequestDto filtro)
        {
            try
            {
                var result = await _projetoService.ConsultarProjeto(filtro);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(CreateObjectError(ex.Message));
            }
        }
     
    }
}
