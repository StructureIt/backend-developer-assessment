using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchApiService.Models
{
    public class AlbumResultsViewModel : IdentityDomainModel
    {
        public ICollection<AlbumViewModel> Releases
        {
            get;
            set;
        }
    }
}