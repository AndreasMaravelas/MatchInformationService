using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Models;
using MatchInformation.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.Match.Commands.CreateMatch
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, CreateMatchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public CreateMatchCommandHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<CreateMatchResponse> Handle(CreateMatchCommand request, CancellationToken cancellationToken = default)
        {
            var createMatchResponse = new CreateMatchResponse();
            var validator = new CreateMatchValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                AddErrorResults(createMatchResponse, validationResult);
            }
            if (createMatchResponse.Success)
            {
                await AddSuccessResults(request, createMatchResponse, cancellationToken);
            }

            return createMatchResponse;
        }

        private async Task AddSuccessResults(CreateMatchCommand request, CreateMatchResponse createMatchResponse, CancellationToken cancellationToken)
        {
            var match = _mapper.Map<MatchEntity>(request);
            var result = await _matchRepository.AddAsync(match, cancellationToken);
            createMatchResponse.Match = _mapper.Map<MatchDto>(result);
        }

        private static void AddErrorResults(CreateMatchResponse createMatchResponse, FluentValidation.Results.ValidationResult validationResult)
        {
            createMatchResponse.Success = false;
            createMatchResponse.ValidationErrors = new List<string>();
            createMatchResponse.ValidationErrors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
