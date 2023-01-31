using AppData.Application.Features.FPersonas.Commands.CreatePersona;
using AppData.Application.Features.FPersonas.Commands.DeletePersona;
using AppData.Application.Features.FPersonas.Commands.UpdatePersona;
using AppData.Application.Features.Persona.Queries.GetPersonaList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonaController(IMediator mediator) => _mediator = mediator;

        //[HttpGet("{Nombres}", Name = "GetPersona")]
        [HttpGet(Name = "GetPersona")]
        //[HttpGet(Name = "GetPersona")]
        [ProducesResponseType(typeof(IEnumerable<PersonaVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PersonaVm>>> GetPersona(string? Nombres, string? Dni, string? Referencia, string? Direccion)
        {
            var query = new GetPersonaQuery(Nombres, Dni, Referencia, Direccion);
            var cliente = await _mediator.Send(query);
            return Ok(cliente);
        }

        [HttpPost(Name = "CreatePersona")]
        //[Authorize(Roles = "Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreatePersona([FromBody] PersonaCommand cliente)
        {
            return Ok(await _mediator.Send(cliente));
        }

        [HttpPut("{PersonaId}",Name = "UpdateCliente")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCliente([FromBody] UpdatePersonaCommand cliente)
        {
            return Ok(await _mediator.Send(cliente));
        }

        [HttpDelete("{PersonaId}", Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCliente(int PersonaId, int UserId)
        {
            var command = new DeletePersonaCommand
            {
                PersonaId = PersonaId,
                UserId = UserId
            };
            return Ok(await _mediator.Send(command));
        }
    }
}
