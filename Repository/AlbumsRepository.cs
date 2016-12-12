using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
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

        static readonly HttpClient Client = new HttpClient();

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
            var artistAlbums = GetArtistAlbums(artistid).Result;
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

        private async Task<AlbumResults> GetArtistAlbums(Guid artistId)
        {
            //TODO: Need to move url to configuration section
            // example url http://musicbrainz.org/ws/2/release?artist=650e7db6-b795-4eb5-a702-5ea2fc46c848&inc=artist-credits+labels+recordings&fmt=json
            var url = $"http://musicbrainz.org/ws/2/release?artist={artistId}&inc=artist-credits+labels+recordings&fmt=json";

            var responseMessage = string.Empty;

            HttpRequestHeaders requestHeaders = Client.DefaultRequestHeaders;
            //requestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            requestHeaders.Add("user-agent", "Nav Music Xbox/1.0 (navamohank@gmail.com)");
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            var task = Client.SendAsync(request)
                .ContinueWith((taskwithmsg) =>
                {
                    var response = taskwithmsg.Result;

                    var responseTask = response.Content.ReadAsStringAsync();
                    responseTask.Wait();
                    responseMessage = responseTask.Result;
                });
            task.Wait();

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
            return albums;
        }
    }
}