using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syntra.Modules.Management.Presentation.Contracts.Requests;
using Syntra.Modules.Management.Application.ApiClients.CreateClient;
using Syntra.Modules.Management.Application.ApiClients.GetByClientId;

namespace Syntra.Modules.Management.Presentation.Controllers
{
    [ApiController]
    [Route("api/managament/[controller]")]
    public class ApiClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetByClientId(string clientId, CancellationToken cancellationToken)
        {
            GetByClientIdQuery query = new GetByClientIdQuery(clientId);
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApiClientRequest request, CancellationToken cancellationToken)
        {
            CreateApiClientCommand command = new CreateApiClientCommand(request.Name, request.Description);
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
