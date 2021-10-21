using LibraryFromNuget.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFromNuget.Interfaces
{
    public interface ISomeService
    {
        public Task SaveSomeManagedModel(SomeManagedModel model);
    }
}
