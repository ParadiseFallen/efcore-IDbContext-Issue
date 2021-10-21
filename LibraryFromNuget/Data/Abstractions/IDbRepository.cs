using LibraryFromNuget.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryFromNuget.Data.Abstractions
{
    //you has no IDBContext
    public interface IDbRepository : IDBContext
    {
        public DbSet<SomeManagedModel> SomeManagedModels { get; set; }
    }
}
