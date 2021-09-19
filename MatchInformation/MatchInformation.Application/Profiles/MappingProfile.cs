using AutoMapper;
using MatchInformation.Application.Features.Match.Commands.CreateMatch;
using MatchInformation.Application.Models;
using MatchInformation.Domain.Entities;

namespace MatchInformation.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MatchEntity, MatchDto>();
            CreateMap<MatchOddsEntity, MatchOddsDto>();

            CreateMap<CreateMatchCommand, MatchEntity>();
        }
    }
}
