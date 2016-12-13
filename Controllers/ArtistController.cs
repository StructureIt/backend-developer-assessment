using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchApiService.Models;
using System.Threading.Tasks;
using SearchApiService.Repository;
using SearchApiService.Models.ViewModels;

namespace SearchApiService.Controllers
{
    [RoutePrefix("api/v1/artist")]
    public class ArtistController : ApiController
    {
        private readonly IReadOnlyRepository<Artist, Guid> _artistRepository;
        private readonly IResultsRepository<AlbumResultsViewModel, Guid> _albumRepository;

        public ArtistController(IReadOnlyRepository<Artist, Guid> repository, IResultsRepository<AlbumResultsViewModel, Guid> albumRepository)
        {
            _artistRepository = repository;
            _albumRepository = albumRepository;
        }

        private HttpResponseMessage SendErrorResponseMessage(string entity)
        {
            var message = $"No records found for your search term {entity}";
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
        }

        // GET: api/v1/artist/getall
        [Route("getall")]
        public HttpResponseMessage Get()
        {
            var allArtists = _artistRepository.GetAll();

            if (allArtists != null)
                return Request.CreateResponse(HttpStatusCode.OK, allArtists);

            return SendErrorResponseMessage(string.Empty);
        }

        // GET: api/v1/artist/search/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/details
        [Route("search/{artistId:guid}/details")]
        [HttpGet]
        public HttpResponseMessage SearchById(Guid artistId)
        {
            var artistResult = _artistRepository.GetById(artistId);

            if (artistResult != null)
                return Request.CreateResponse(HttpStatusCode.OK, artistResult);

            return SendErrorResponseMessage(artistId.ToString());
        }

        // GET: api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a
        [Route("{artistId:guid}/albums")]
        [HttpGet]
        public HttpResponseMessage GetAlbums(Guid artistId)
        {
            var artistResult = _albumRepository.GetById(artistId);

            if (artistResult != null)
                return Request.CreateResponse(HttpStatusCode.OK, artistResult);

            return SendErrorResponseMessage(artistId.ToString());
        }

        // GET: api/v1/artist/search/joh/1/5
        [Route("search/{query:maxlength(50)}/{index:int=1}/{size:int=100}")]
        [HttpGet]
        public HttpResponseMessage SearchByName([FromUri]SearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var artistResult = _artistRepository.SearchByName(request);

            if (artistResult == null || !artistResult.Any())
                return SendErrorResponseMessage(request.Query);

            var result = new ArtistResultsViewModel
            {
                Page = request.Index,
                PageSize = request.Size,
                ResultsCount = artistResult.Count()
            };

            // changed logic from 0 based index to 1
            result.Results = artistResult.Skip((request.Index - 1) * request.Size).Take(request.Size).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/releases
        [Route("{artistId:guid}/releases")]
        public HttpResponseMessage GetReleases(Guid artistId)
        {
            //Uncomment the line below to get list of releases from music db
            //var url = @"http://musicbrainz.org/ws/2/release?artist=" + artistId + "&inc=labels+recordings&fmt=json";
            
            var albumResult = _albumRepository.GetById(artistId);

            if (albumResult != null)
                return Request.CreateResponse(HttpStatusCode.OK, albumResult);

            return SendErrorResponseMessage(artistId.ToString());
        }
    }
}
