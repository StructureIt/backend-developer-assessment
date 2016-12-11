using System.Collections.Generic;

namespace SearchApiService.Models.ViewModels
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
