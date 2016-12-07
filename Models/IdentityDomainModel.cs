using System;

namespace SearchApiService.Models
{
    public class IdentityDomainModel : IEntityModel
    {
        public Guid Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}