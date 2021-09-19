using AutoMapper;
using MatchInformation.Application.Features.Match.Commands.CreateMatch;
using MatchInformation.Application.Features.Match.Commands.CreateMatchOdds;
using MatchInformation.Application.Models;
using MatchInformation.Domain.Entities;

namespace MatchInformation.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MatchEntity, MatchDto>().ReverseMap();
            CreateMap<MatchOddsEntity, MatchOddsDto>().ReverseMap();

            CreateMap<CreateMatchCommand, MatchEntity>();
            CreateMap<CreateMatchOddsCommand, MatchOddsEntity>();
        }
    }
}
