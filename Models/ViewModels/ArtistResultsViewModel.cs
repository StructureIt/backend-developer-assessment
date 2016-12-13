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
                // PageSize cannot be 0 or negative number as per model validation 
                // ResultsCount can be 0 so will return 0
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
