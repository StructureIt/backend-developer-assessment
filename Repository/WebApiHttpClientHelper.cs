using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SearchApiService.Repository
{
    public abstract class WebApiHttpClientHelper
    {
        static readonly HttpClient Client = new HttpClient();

        public static string GetResponseFromMusicBrainzApi(string url)
        {
            var responseMessage = string.Empty;

            var requestHeaders = Client.DefaultRequestHeaders;
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

            return responseMessage;
        }
    }
}