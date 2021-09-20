using AutoFixture;
using AutoMapper;
using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Application.Features.Match.Queries.GetMatch;
using MatchInformation.Application.Models;
using MatchInformation.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchInformation.Application.Tests.Features.Match
{
    public class GetMatchQueryHandlerTests
    {
        private readonly Fixture _fixture;
        private readonly GetMatchQueryHandler _handler;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMatchRepository> _repositoryMock;

        public GetMatchQueryHandlerTests()
        {
            _fixture = new Fixture();
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IMatchRepository>();

            _handler = new GetMatchQueryHandler(
                _mapperMock.Object,
                _repositoryMock.Object);
        }

        [Fact]
        public async Task Given_MatchId_When_Match_Exists_Handle_Returns_MatchDto()
        {
            var matchDto = _fixture.Create<MatchDto>();
            var matchEntity = _fixture
                .Build<MatchEntity>()
                .Without(x => x.Odds)
                .Create();

            var query = new GetMatchQuery { Id = matchDto.ID };

            _repositoryMock
                .Setup(x => x.GetByIdAsync(It.Is<Guid>(d => d == matchDto.ID), It.IsAny<CancellationToken>()))
                .ReturnsAsync(matchEntity)
                .Verifiable();

            _mapperMock
                .Setup(x => x.Map<MatchDto>(matchEntity))
                .Returns(matchDto)
                .Verifiable();

            var result = await _handler.Handle(query);
            
            Assert.True(result.Equals(matchDto));

            _mapperMock.Verify();
            _repositoryMock.Verify();
        }
    }
}
