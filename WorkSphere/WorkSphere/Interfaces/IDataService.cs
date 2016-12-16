using System.Collections.Generic;
using WorkSphere.Models;

namespace WorkSphere.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Coworker> GetCoworkers();
    }
}
