using LibraryFromNuget.Data.Abstractions;
using LibraryFromNuget.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreIDbContextIssue.Data.DB
{
    public class ApplicationDatabaseContext : DbContext , IDbRepository
    {

        // property comes from IDbRepository. IDbRepository comes from NUGET package. IDbRepository is data contract
        public DbSet<SomeManagedModel> SomeManagedModels { get; set; }
    }
}
