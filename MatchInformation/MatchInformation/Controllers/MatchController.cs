using MatchInformation.Application.Features.Match.Commands.CreateMatch;
using MatchInformation.Application.Features.Match.Commands.DeleteMatch;
using MatchInformation.Application.Features.Match.Commands.UpdateMatch;
using MatchInformation.Application.Features.Match.Queries.GetMatch;
using MatchInformation.Application.Features.Match.Queries.GetMatchList;
using MatchInformation.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MatchController> _logger;

        public MatchController(
            IMediator mediator,
            ILogger<MatchController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MatchDto>>> GetAll(CancellationToken token = default)
        {
            return Ok(await _mediator.Send(new GetMatchListQuery(), token));
        }

        [HttpGet("{id", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MatchDto>> Get(Guid id, CancellationToken token = default)
        {
            return Ok(await _mediator.Send(new GetMatchQuery() { Id = id }, token));
        }

        [HttpPost("create", Name = "Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create(
          [FromBody] CreateMatchCommand command, CancellationToken token = default)
        {
            return Ok(await _mediator.Send(command, token));

        }

        [HttpPost("update", Name = "Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Update(
            [FromBody] UpdateMatchCommand command, CancellationToken token = default)
        {
            return Ok(await _mediator.Send(command, token));

        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteById(Guid id, CancellationToken token = default)
        {
            await _mediator.Send(new DeleteMatchCommand() { Id = id }, token);
            return NoContent();
        }
    }
}
