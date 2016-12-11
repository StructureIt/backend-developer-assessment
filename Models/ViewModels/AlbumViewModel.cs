using System;
using System.Collections.Generic;

namespace SearchApiService.Models.ViewModels
{
    public class AlbumViewModel
    {
        public Guid ReleaseId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Label
        {
            get;
            set;
        }

        public int NumberOfTracks
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public ICollection<IdentityDomainModel> OtherArtists
        {
            get;
            set;
        }
    }
}