using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Practices.Unity;
using SearchApiService.Models;

namespace SearchApiService.Repository
{
    public class ArtistRepository : IReadOnlyRepository<Artist, Guid>
    {
        [Dependency]
        public MusicStoreDbEntities context { get; set; }

        public IQueryable<Artist> GetAll()
        {
            return context.artists.ProjectTo<Artist>();
        }

        public Artist GetById(Guid id)
        {
            var artist = context.artists.FirstOrDefault(a => a.globalid.Equals(id));
            return Mapper.Map<Artist>(artist);
        }

        public IQueryable<Artist> SearchByName(SearchRequest request)
        {
            var artistlist = from a in context.artists
                             join al in context.artistalias on a.id equals al.artist into aliases
                             from alias in aliases.Where(i => i.name.Contains(request.Query)).DefaultIfEmpty()
                             where a.name.Contains(request.Query)
                             orderby a.id
                             select a;

            return artistlist.ProjectTo<Artist>();
        }
    }
}