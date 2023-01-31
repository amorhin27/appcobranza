using AppData.Application.Features.FCobranza.Commands.CreateCobranza;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobranzaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CobranzaController(IMediator mediator) => _mediator = mediator;


        [HttpPost(Name = "CreateCobranza")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue, ValueLengthLimit = int.MaxValue)]
        public async Task<ActionResult<int>> CreateCobranza([FromBody] CreateCobranzaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
