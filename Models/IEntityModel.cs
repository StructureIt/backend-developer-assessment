using System;

namespace SearchApiService.Models
{
    public interface IEntityModel
    {
        Guid Id { get; set; }

        string Name { get; set; }
    }
}
