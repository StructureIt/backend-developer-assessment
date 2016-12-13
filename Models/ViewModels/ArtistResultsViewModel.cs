using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SearchApiService.Models.ViewModels
{
    public class ArtistResultsViewModel : IResultsViewModel<Artist>
    {
        [DisplayName("numberOfPages")]
        [JsonProperty("numberOfPages")]
        public int NoOfPages
        {
            get
            {
                if (PageSize <= 0 || ResultsCount <= 0)
                {
                    return 1;
                }
                return (int) Math.Ceiling((decimal) (ResultsCount / PageSize));
            }
        }

        public int Page
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        [DisplayName("numberOfSearchResults")]
        [JsonProperty("numberOfSearchResults")]
        public int ResultsCount
        {
            get;
            set;
        }

        public ICollection<Artist> Results
        {
            get;
            set;
        }
    }
}
