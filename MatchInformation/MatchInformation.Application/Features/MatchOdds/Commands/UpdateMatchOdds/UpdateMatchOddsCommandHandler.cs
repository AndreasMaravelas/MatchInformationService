using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Exceptions;
using MatchInformation.Application.Features.Match.Commands.UpdateMatchOdds;
using MatchInformation.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.MatchOdds.Commands.UpdateMatchOdds
{
    public class UpdateMatchOddsCommandHandler : IRequestHandler<UpdateMatchOddsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMatchOddsRepository _matchOddsRepository;

        public UpdateMatchOddsCommandHandler(IMapper mapper, IMatchOddsRepository matchOddsRepository)
        {
            _mapper = mapper;
            _matchOddsRepository = matchOddsRepository;
        }

        public async Task<Unit> Handle(UpdateMatchOddsCommand request, CancellationToken cancellationToken)
        {
            var matchToUpdate = await _matchOddsRepository.GetByIdAsync(request.Id);

            if (matchToUpdate == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            var validator = new UpdateMatchOddsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, matchToUpdate, typeof(UpdateMatchOddsCommand), typeof(MatchOddsEntity));

            await _matchOddsRepository.UpdateAsync(matchToUpdate);

            return Unit.Value;
        }
    }
}
