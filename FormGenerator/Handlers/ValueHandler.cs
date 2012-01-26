using FormGenerator.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace FormGenerator.Handlers
{
    public class ValueHandler : ContentHandler
    {
        public ValueHandler(IRepository<Value> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}