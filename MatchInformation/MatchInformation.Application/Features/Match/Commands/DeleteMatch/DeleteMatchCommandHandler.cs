using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Features.Match.Commands.DeleteMatch
{
    public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public DeleteMatchCommandHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<Unit> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetByIdAsync(request.Id);

            if (match == null)
            {
                throw new NotFoundException(nameof(Match), request.Id);
            }

            await _matchRepository.DeleteAsync(match);

            return Unit.Value;
        }
    }
}
