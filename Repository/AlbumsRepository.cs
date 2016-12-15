using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using SearchApiService.Models;
using SearchApiService.Models.DataContract;
using SearchApiService.Models.ViewModels;

namespace SearchApiService.Repository
{
    public class AlbumsRepository : IResultsRepository<AlbumResultsViewModel, Guid>
    {
        [Dependency]
        protected MusicStoreDbEntities Context { get; set; }

        public AlbumResultsViewModel GetById(Guid artistid)
        {
            var albumResults = new AlbumResultsViewModel
            {
                Id = artistid,
                Name = string.Empty,
                Releases = new List<AlbumViewModel>()
            };

            var artist = Context.artists.FirstOrDefault(a => a.globalid.Equals(artistid));
            if (artist == null)
            {
                albumResults.Name = "Artist Not Found";
                return albumResults;
            }

            albumResults.Name = artist.name;

            //Get Releases for artistid from musicbrainz web api or static content from Json values
            var artistAlbums = GetArtistAlbums(artistid);
            if (artistAlbums.Releases.Any())
            {
                albumResults.Releases = Mapper.Map<List<AlbumViewModel>>(artistAlbums.Releases);
                return albumResults;
            }

            // Return releases from Database
            var result = from ar in artist.artistreleases
                         select ar.release;

            foreach (var item in result)
            {
                albumResults.Releases.Add(Mapper.Map<AlbumViewModel>(item));
            }

            return albumResults;
        }

        private AlbumResults GetArtistAlbums(Guid artistId)
        {
            var url =
                $"http://musicbrainz.org/ws/2/release?artist={artistId}&inc=artist-credits+labels+recordings+release-groups&fmt=json";
            var responseMessage = WebApiHttpClientHelper.GetResponseFromMusicBrainzApi(url);

            if (responseMessage.IsNullOrWhiteSpace())
            {
                // Search file stream to simulate album results from static Json response
                return LoadResultsFromJson(artistId);
            }

            return GetAlbumResults(responseMessage);
        }

        private static AlbumResults LoadResultsFromJson(Guid artistId)
        {
            var jsonArtistReleasesFilePath = System.Web.Hosting.HostingEnvironment.MapPath($@"~/App_Data/{artistId}.json");

            if (jsonArtistReleasesFilePath == null || !File.Exists(jsonArtistReleasesFilePath))
            {
                return new AlbumResults();
            }

            using (var r = new StreamReader(jsonArtistReleasesFilePath))
            {
                var json = r.ReadToEnd();
                return GetAlbumResults(json);
            }
        }

        private static AlbumResults GetAlbumResults(string json)
        {
            var jObject = JObject.Parse(json);
            //TODO: Need to add validation for proper json response
            var albums = jObject.ToObject<AlbumResults>();
            if (albums.Releases == null || albums.Releases.All(r => r.ReleaseGroup == null))
                return albums;

            var albumFilter =
                albums.Releases.Where(r => r.ReleaseGroup != null && r.ReleaseGroup.Primarytype == "Album").OrderBy(r => r.Title).Take(10).ToList();
            albums.Releases = albumFilter;

            return albums;
        }
    }
}