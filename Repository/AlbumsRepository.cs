using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Practices.Unity;
using SearchApiService.Models;

namespace SearchApiService.Repository
{
    public class AlbumsRepository : IResultsRepository<AlbumResultsViewModel, Guid>
    {
        [Dependency]
        protected MusicStoreDbEntities Context { get; set; }

        public AlbumResultsViewModel GetById(Guid id)
        {
            var artist = Context.artists.FirstOrDefault(a => a.globalid.Equals(id));
            if (artist == null)
            {
                return new AlbumResultsViewModel()
                {
                    Id = id,
                    Name = "Not a valid Identity"
                };
            }

            var result = from ar in artist.artistreleases
                         select ar.release;

            var albums = new AlbumResultsViewModel
            {
                Id = id,
                Name = artist.name,
                Releases = new List<AlbumViewModel>()
            };

            foreach (var item in result)
            {
                albums.Releases.Add(Mapper.Map<AlbumViewModel>(item));
            }
            return albums;
        }

    }

}