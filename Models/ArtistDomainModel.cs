using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchApiService.Models
{
    public class Artist : IdentityDomainModel
    {
        public string Country {
            get;
            set;
        }
        public ICollection<string> alias {
            get;
            set;
        }
    }
}