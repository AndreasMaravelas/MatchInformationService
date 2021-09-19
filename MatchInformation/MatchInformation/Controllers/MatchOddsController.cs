using MatchInformation.Application.Features.Match.Commands.CreateMatchOdds;
using MatchInformation.Application.Features.Match.Commands.DeleteMatchOdds;
using MatchInformation.Application.Features.Match.Commands.UpdateMatchOdds;
using MatchInformation.Application.Features.Match.Queries.GetMatchOdds;
using MatchInformation.Application.Features.Match.Queries.GetMatchOddsList;
using MatchInformation.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchOddsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MatchOddsController> _logger;

        public MatchOddsController(
            IMediator mediator,
            ILogger<MatchOddsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "Get all match odds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MatchOddsDto>>> GetAll(CancellationToken token = default)
        {
            return Ok(await _mediator.Send(new GetMatchOddsListQuery(), token));
        }

        [HttpGet("{id}", Name = "Get match odds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MatchDto>> Get(Guid id, [FromQuery] Guid matchId, CancellationToken token = default)
        {
            return Ok(await _mediator.Send(new GetMatchOddsQuery() { Id = id }, token));
        }

        [HttpPost("create", Name = "Create odds for match")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create(
          [FromBody] CreateMatchOddsCommand command, CancellationToken token = default)
        {
            return Ok(await _mediator.Send(command, token));

        }

        [HttpPost("update", Name = "Update odds for match")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Update(
            [FromBody] UpdateMatchOddsCommand command, CancellationToken token = default)
        {
            return Ok(await _mediator.Send(command, token));

        }

        [HttpDelete("{id}", Name = "Delete odds")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteById(Guid id, CancellationToken token = default)
        {
            await _mediator.Send(new DeleteMatchOddsCommand() { Id = id }, token);
            return NoContent();
        }
    }
}
