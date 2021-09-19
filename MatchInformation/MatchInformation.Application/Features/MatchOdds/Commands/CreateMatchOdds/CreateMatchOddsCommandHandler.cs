using AutoMapper;
using FluentValidation.Results;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Features.Match.Commands.CreateMatchOdds;
using MatchInformation.Application.Models;
using MatchInformation.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.MatchOdds.Commands.CreateMatchOdds
{
    public class CreateMatchOddsCommandHandler : IRequestHandler<CreateMatchOddsCommand, CreateMatchOddsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMatchOddsRepository _matchOddsRepository;

        public CreateMatchOddsCommandHandler(IMatchOddsRepository matchOddsRepository, IMapper mapper)
        {
            _matchOddsRepository = matchOddsRepository;
            _mapper = mapper;
        }

        public async Task<CreateMatchOddsResponse> Handle(CreateMatchOddsCommand request, CancellationToken token = default)
        {
            var createMatchOddsResponse = new CreateMatchOddsResponse();
            var validator = new CreateMatchOddsValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                AddErrorResults(createMatchOddsResponse, validationResult);
            }
            if (createMatchOddsResponse.Success)
            {
                await AddSuccessResults(request, createMatchOddsResponse, token);
            }

            return createMatchOddsResponse;
        }

        private async Task AddSuccessResults(CreateMatchOddsCommand request, CreateMatchOddsResponse response, CancellationToken cancellationToken)
        {
            var match = _mapper.Map<MatchOddsEntity>(request);
            var result = await _matchOddsRepository.AddAsync(match, cancellationToken);
            response.MatchOdds = _mapper.Map<MatchOddsDto>(result);
        }

        private static void AddErrorResults(CreateMatchOddsResponse response, ValidationResult validationResult)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();
            response.ValidationErrors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
