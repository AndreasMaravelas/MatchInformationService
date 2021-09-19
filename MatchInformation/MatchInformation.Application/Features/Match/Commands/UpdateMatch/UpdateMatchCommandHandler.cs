using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Exceptions;
using MatchInformation.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.Match.Commands.UpdateMatch
{
    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public UpdateMatchCommandHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<Unit> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            var matchToUpdate = await _matchRepository.GetByIdAsync(request.Id);

            if (matchToUpdate == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            var validator = new UpdateMatchCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, matchToUpdate, typeof(UpdateMatchCommand), typeof(MatchEntity));

            await _matchRepository.UpdateAsync(matchToUpdate);

            return Unit.Value;
        }
    }
}
