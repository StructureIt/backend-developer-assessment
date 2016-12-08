using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchApiService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SearchApiService.Models;

namespace SearchApiService.Controllers.Tests
{
    [TestClass]
    public class ArtistControllerTests
    {
        HttpClient client = null;
        string baseAddress = null;

        public ArtistControllerTests()
        {
            baseAddress = "http://localhost:55312/";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        [TestMethod]
        public void GetAllArtists()
        {
            HttpResponseMessage response = client.GetAsync("api/v1/artist/getall").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            IEnumerable<Artist> values = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;

            Assert.IsNotNull(values);
            Assert.AreEqual(true, values.ToList().Any());
        }
        
        // GET: api/v1/artist/search/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/details
        [TestMethod()]
        public void SearchByIdTest()
        {
            HttpResponseMessage response = client.GetAsync("api/v1/artist/search/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/details").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // GET: api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/albums
        [TestMethod()]
        public void GetAlbumsTest()
        {
            HttpResponseMessage response = client.GetAsync("api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/albums").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // GET: api/v1/artist/search/joh/0/5
        [TestMethod()]
        public void SearchByNameTest()
        {
            HttpResponseMessage response = client.GetAsync("api/v1/artist/search/joh/1/5").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // GET: api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/releases
        [TestMethod()]
        public void GetReleasesTest()
        {
            HttpResponseMessage response = client.GetAsync("api/v1/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a/releases").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}