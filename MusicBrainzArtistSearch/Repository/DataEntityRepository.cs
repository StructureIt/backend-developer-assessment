using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicBrainzArtistSearch.Models;

namespace MusicBrainzArtistSearch.Repository
{
    public class DataEntityRepository : IDataEntityRepository
    {
        private MusicBrainzDBEntities _db;

        public DataEntityRepository(MusicBrainzDBEntities db)
        {
            this._db = db;
        }

        public List<ResultDataModels> GetAllArtist()
        {
            List<ResultDataModels> resultSet = new List<ResultDataModels>();
            List<ArtistDataModels> artistList = new List<ArtistDataModels>();

            foreach (Artist artist in _db.Artists.OrderBy(o => o.id))
            {                List<string> aliases = new List<string>();
                foreach (Alias alias in artist.Aliases)
                {
                    aliases.Add(alias.aliasname);
                }
                artistList.Add(new ArtistDataModels(artist.artistname, artist.country, aliases));
            }

            if (artistList.Count == 0) //no returned elements
            {
                resultSet = null;
            } else
            {
                resultSet.Add(new ResultDataModels(artistList, artistList.Count));
            }

            return resultSet;
        }

        public List<ResultDataModels> GetAllArtistByName(string name)
        {
            List<ResultDataModels> resultSet = new List<ResultDataModels>();
            List<ArtistDataModels> artistList = new List<ArtistDataModels>();

            var artistJoin = from queryArtist in _db.Artists
                             join queryAlias in _db.Aliases on queryArtist.id equals queryAlias.artistid
                             where queryArtist.artistname.Contains(name) || queryAlias.aliasname.Contains(name)
                             group queryArtist by new { queryArtist.id };

            foreach (var groups in artistJoin.ToList())
            {
                int artistId = groups.Key.id;
                Artist artist = _db.Artists.Find(artistId);

                List<string> aliases = new List<string>();
                foreach (Alias alias in artist.Aliases)
                {
                    aliases.Add(alias.aliasname);
                }
                artistList.Add(new ArtistDataModels(artist.artistname, artist.country, aliases));
            }


            if (artistList.Count == 0) //no returned elements
            {
                resultSet = null;
            }
            else
            {
                resultSet.Add(new ResultDataModels(artistList, artistList.Count));
            }

            return resultSet;
        }

        public List<ResultDataModels> GetAllArtistByNameWithPagination(string name, int pageNumber, int pageSize)
        {
            List<ResultDataModels> resultSet = new List<ResultDataModels>();
            List<ArtistDataModels> artistList = new List<ArtistDataModels>();

            //materialize original query so we don't have to do 2 queries
            int totalSearchResults = 0;
            var artistJoin = from queryArtist in _db.Artists
                             join queryAlias in _db.Aliases on queryArtist.id equals queryAlias.artistid
                             where queryArtist.artistname.Contains(name) || queryAlias.aliasname.Contains(name)
                             group queryArtist by new { queryArtist.id };

            totalSearchResults = artistJoin.ToList().Count();

            foreach (var groups in artistJoin.OrderBy(o => o.Key.id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList())
            {
                int artistId = groups.Key.id;
                Artist artist = _db.Artists.Find(artistId);

                List<string> aliases = new List<string>();
                foreach (Alias alias in artist.Aliases)
                {
                    aliases.Add(alias.aliasname);
                }
                artistList.Add(new ArtistDataModels(artist.artistname, artist.country, aliases));
            }

            if (artistList.Count == 0) //no returned elements
            {
                resultSet = null;
            }
            else
            {
                //call some pagination stuff here since we have results
                resultSet.Add(new ResultDataModels(artistList, totalSearchResults, pageNumber, pageSize).CalculatePagination());
            }

            return resultSet;
        }


        public List<ResultDataModels> GetArtistById(int id)
        {
            List<ResultDataModels> resultSet = new List<ResultDataModels>();
            List<ArtistDataModels> artistList = new List<ArtistDataModels>();

            var artist = _db.Artists.Find(id);

            if(artist == null)
            {
                artist = null;
            }

            List<string> aliases = new List<string>();

            foreach (Alias alias in artist.Aliases)
            {
                aliases.Add(alias.aliasname);
            }

            artistList.Add(new ArtistDataModels(artist.artistname, artist.country, aliases));

            if (artistList.Count == 0) //no returned elements
            {
                resultSet = null;
            }
            else
            {
                resultSet.Add(new ResultDataModels(artistList, artistList.Count));
            }

            return resultSet;
        }
    }
}