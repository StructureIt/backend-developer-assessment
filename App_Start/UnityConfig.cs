using System;
using Microsoft.Practices.Unity;
using System.Web.Http;
using SearchApiService.Models;
using SearchApiService.Repository;
using Unity.WebApi;

namespace SearchApiService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDatabaseRepository<Artist, Guid>, ArtistRepository>();
            container.RegisterType<IResultsRepository<AlbumResultsViewModel, Guid>, AlbumsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}