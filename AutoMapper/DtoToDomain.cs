using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using SearchApiService.Models;
using SearchApiService.Models.DataContract;
using SearchApiService.Models.ViewModels;


namespace SearchApiService.AutoMapper
{
    public class DtoToDomain : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainProfile"; }
        }

        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
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

            //DbContext to Album Viewmodel conversion
            CreateMap<release, AlbumViewModel>()
                .ForMember(d => d.ReleaseId, opt => opt.MapFrom(src => src.globalid))
                .ForMember(d => d.Date, opt =>
                {
                    opt.Condition(src => src.releasedate.HasValue);
                    opt.MapFrom(src => src.releasedate.Value.ToString("yyyy-MM-dd"));
                })
                .ForMember(d => d.NumberOfTracks, opt =>
                {
                    opt.Condition(src => src.trackscount.HasValue);
                    opt.MapFrom(src => src.trackscount.Value);
                })
                .ForMember(d => d.OtherArtists,
                    opt => opt.MapFrom(src => src.artistreleases.Select(ar => ar.artist).ToList()));

            CreateMap<Artistcredit, IdentityDomainModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Artist.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Artist.Name));

            //WebApi Release object to Album Viewmodel flat structure conversion
            CreateMap<Release, AlbumViewModel>()
                .ForMember(d => d.ReleaseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Label, opt =>
                {
                    opt.Condition(src => src.Labelinfo != null && src.Labelinfo.Any() && src.Labelinfo.Count > 0);
                    opt.MapFrom(src => src.Labelinfo.Select(l => l.Releaselabel).ToList().FirstOrDefault().Name);
                }
                )
                .ForMember(d => d.Date, opt =>
                {
                    opt.Condition(src => src.Date.IsNullOrWhiteSpace() == false);
                    opt.MapFrom(src => src.Date);
                })
                .ForMember(d => d.NumberOfTracks, opt =>
                {
                    opt.Condition(src => src.Media.Any());
                    opt.MapFrom(src => src.Media.Select(m => m.NumberOfTracks).First());
                })
                .ForMember(d => d.OtherArtists, opt =>
                {
                    opt.Condition(src => src.Media.Any() && src.Media.Any(m => m.Tracks.Any()));
                    opt.ResolveUsing(src => GetOtherArtists(src.Media));
                });
        }

        private static List<IdentityDomainModel> GetOtherArtists(ICollection<MediaItem> media)
        {
            HashSet<IdentityDomainModel> otherArtists = new HashSet<IdentityDomainModel>();
            foreach (var i in media.SkipWhile(m => m.Tracks == null))
            {
                foreach (var t in i.Tracks.SkipWhile(t => t.Otherartists == null))
                {
                    foreach (var a in t.Otherartists)
                    {
                        if (otherArtists.Any(oa => oa.Id.Equals(a.Artist.Id)))
                            continue;

                        otherArtists.Add(a.Artist);
                    }
                }

            }
            return otherArtists.ToList();
        }
    }
}