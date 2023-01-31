using AppData.Application.Features.FPrestamo.Commmands.CreatePrestamo;
using AppData.Application.Features.FPrestamo.Queries.GetPrestamo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrestamoController(IMediator mediator) => _mediator = mediator;

        [HttpPost(Name = "CreatePrestamo")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [DisableRequestSizeLimit,RequestFormLimits(MultipartBodyLengthLimit =int.MaxValue, ValueLengthLimit = int.MaxValue)]
        //public async Task<ActionResult<int>> CreatePrestamo([FromForm] CreatePrestamoCommand command)
        public async Task<ActionResult<int>> CreatePrestamo([FromBody] CreatePrestamoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet(Name = "GetPrestamoCliente")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<GetPrestamoVm>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPrestamoCliente(string? Dni, string? Nombres, string? Direccion, string? Referencia)
        {
            var query = new GetPrestamoQuery(Dni, Nombres, Direccion, Referencia);
            var prestamo = await _mediator.Send(query);
            return Ok(prestamo);
        }

    }
}
