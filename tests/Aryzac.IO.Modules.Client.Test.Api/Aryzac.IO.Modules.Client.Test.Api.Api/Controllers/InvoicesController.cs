using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Api.Controllers.ResponseTypes;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.ChangeDueDateInvoice;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.CreateInvoice;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.DeleteInvoice;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.GetInvoiceById;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.GetInvoices;
using Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.GetInvoicesByClientId;
using Asp.Versioning;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class InvoicesController : ControllerBase
    {
        private readonly ISender _mediator;

        public InvoicesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">One or more entities could not be found with the provided parameters.</response>
        [HttpPut("api/v{version:apiVersion}/invoice/{id}/change-due-date")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> ChangeDueDateInvoice(
            [FromRoute] Guid id,
            [FromBody] ChangeDueDateInvoiceCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.Id == default)
            {
                command.Id = id;
            }

            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("api/v{version:apiVersion}/invoice")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateInvoice(
            [FromBody] CreateInvoiceCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = result }, new JsonResponse<Guid>(result));
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">One or more entities could not be found with the provided parameters.</response>
        [HttpDelete("api/v{version:apiVersion}/invoice/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> DeleteInvoice([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteInvoiceCommand(id: id), cancellationToken);
            return Ok();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified InvoiceDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">No InvoiceDto could be found with the provided parameters.</response>
        [HttpGet("api/v{version:apiVersion}/invoice/{id}")]
        [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InvoiceDto>> GetInvoiceById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetInvoiceByIdQuery(id: id), cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;InvoiceDto&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">No List&lt;InvoiceDto&gt; could be found with the provided parameters.</response>
        [HttpGet("api/v{version:apiVersion}/invoice/by/client/{clientId}")]
        [ProducesResponseType(typeof(List<InvoiceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<InvoiceDto>>> GetInvoicesByClientId(
            [FromRoute] Guid clientId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetInvoicesByClientIdQuery(clientId: clientId), cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;InvoiceDto&gt;.</response>
        [HttpGet("api/v{version:apiVersion}/invoice")]
        [ProducesResponseType(typeof(List<InvoiceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<InvoiceDto>>> GetInvoices(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetInvoicesQuery(), cancellationToken);
            return Ok(result);
        }
    }
}