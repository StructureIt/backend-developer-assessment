﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SearchApiService.Models
{
    public class ArtistResultsViewModel : IResultsViewModel<Artist>
    {
        [DisplayName("numberOfPages")]
        public int NoOfPages
        {
            get
            {
                if (PageSize <= 0 || ResultsCount <= 0)
                {
                    return 1;
                }
                return ResultsCount / PageSize;
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