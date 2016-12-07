using System.Linq;
using AutoMapper;
using SearchApiService.Models;
using WebGrease.Css.Extensions;


namespace SearchApiService.AutoMapper
{
    public class DtoToDomain : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainProfile"; }
        }

        protected override void Configure()
        {
            AllowNullCollections = false;

            MapDtoToDomain();

        }

        private void MapDtoToDomain()
        {
            CreateMap<artist, Artist>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.globalid))
                .ForMember(d => d.alias, opt => opt.MapFrom(src => src.artistalias.Select(a => a.name).ToList()));

            CreateMap<artist, IdentityDomainModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.globalid))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.name));

            CreateMap<release, AlbumViewModel>()
                .ForMember(d => d.ReleaseId, opt => opt.MapFrom(src => src.globalid))
                .ForMember(d => d.Date, opt => opt.MapFrom(src => src.releasedate))
                .ForMember(d => d.NumberOfTracks, opt =>
                {
                    opt.Condition(src => src.trackscount.HasValue);
                    opt.MapFrom(src => src.trackscount.Value);
                })
                .ForMember(d => d.OtherArtists, opt => opt.MapFrom(src => src.artistreleases.Select(ar => ar.artist).ToList()));
        }
    }
}