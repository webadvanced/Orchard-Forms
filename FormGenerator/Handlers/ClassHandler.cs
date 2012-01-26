using FormGenerator.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace FormGenerator.Handlers
{
    public class ClassHandler : ContentHandler
    {
        public ClassHandler(IRepository<Class> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}