using LibraryFromNuget.Data.Abstractions;
using LibraryFromNuget.Data.Models;
using LibraryFromNuget.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFromNuget.Services
{
    public class ServiceThatManageModel : ISomeService
    {
        private IDbRepository Repository { get; set; } 
        public ServiceThatManageModel(IDbRepository repository)
        {
            Repository = repository;
        }
        public Task SaveSomeManagedModel(SomeManagedModel model)
        {
            // do some staff. write to local file as examle binary copy of model

            Repository.SomeManagedModels.Add(model);

            //you cant call SaveChanges or SaveChangesAsync on repository cuz you dont have IDbContext interface
            return Repository.SaveChangesAsync();
        }
    }
}
