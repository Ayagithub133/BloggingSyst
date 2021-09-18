using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public interface ISeedingRoles
    {
        public Task seedRoles(string Id);
    }
}
