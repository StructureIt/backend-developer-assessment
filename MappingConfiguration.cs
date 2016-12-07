using System;
using System.Diagnostics;
using AutoMapper;
using SearchApiService.AutoMapper;

namespace SearchApiService
{
    public static class MappingConfiguration
    {
        public static void RegisterMappings()
        {
            Debug.WriteLine("RegisterMappings Start: {0}", DateTime.Now.ToLongTimeString());
            Mapper.Initialize(x =>
            {
                x.AddProfile<DtoToDomain>();
            });
            Debug.WriteLine("RegisterMappings End: {0}", DateTime.Now.ToLongTimeString());
        }
    }
}