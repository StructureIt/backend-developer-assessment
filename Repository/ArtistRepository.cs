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
            // Query to search for records with name in artist table or alias table
            var artistlist = from a in context.artists
                             select new { artistObject = a, aliasCollection = a.artistalias }
                             into newlist
                             where
                                 newlist.artistObject.name.Contains(request.Query) ||
                                 newlist.aliasCollection.Any(al => al.name.Contains(request.Query))
                             orderby newlist.artistObject.name
                             select newlist.artistObject;

            return artistlist.ProjectTo<Artist>();
        }
    }
}