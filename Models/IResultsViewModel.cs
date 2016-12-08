using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchApiService.Models
{
    interface IResultsViewModel<TEntity> where TEntity : class
    {
        int Page
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        int ResultsCount
        {
            get;
            set;
        }

        int NoOfPages
        {
            get;
        }

        ICollection<TEntity> Results {
            get;
            set;
        }
    }
}
