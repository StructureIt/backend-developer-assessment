using System.Collections.Generic;

namespace SearchApiService.Models.ViewModels
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