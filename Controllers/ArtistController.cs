using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchApiService.Models;
using System.Threading.Tasks;
using SearchApiService.Repository;

namespace SearchApiService.Controllers
{
    [RoutePrefix("api/v1/artist")]
    public class ArtistController : ApiController
    {
        private readonly IDatabaseRepository<Artist, Guid> _artistRepository;
        private readonly IResultsRepository<AlbumResultsViewModel, Guid> _albumRepository;

        static HttpClient client = new HttpClient();

        public ArtistController(IDatabaseRepository<Artist, Guid> repository, IResultsRepository<AlbumResultsViewModel, Guid> albumRepository)
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

        // GET: api/v1/artist/search/joh/0/5
        [Route("search/{query:maxlength(50)}/{index:int=0}/{size:int=100}")]
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

            // Implemented paging here in a traditional way, can be enhanced with the help of OData webapi concepts 
            var artistList = artistResult.ToList();
            if (artistResult.Count() >= request.Index * request.Size && artistResult.Count() >= request.Size)
            {
                artistList = request.Index > 0 ? artistResult.Skip(request.Index * request.Size).Take(request.Size).ToList() : artistResult.Take(request.Size).ToList();
            }
            result.Results = artistList;

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/releases
        [Route("{artistId:guid}/releases")]
        public async Task<JsonActionResult> GetReleases(Guid artistId)
        {
            //Uncomment the line below to get list of releases from music db
            //var url = @"http://musicbrainz.org/ws/2/release?artist=" + artistId + "&inc=labels+recordings&fmt=json";

            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority) + Configuration.VirtualPathRoot;
            var url = $"{baseUrl}/api/v1/artist/{artistId}/albums";
            var responseMessage = await client.GetAsync(url);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new JsonActionResult("{ error : 'No data found'}");
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;
            return new JsonActionResult(responseData);
        }
    }
}
