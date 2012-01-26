using FormGenerator.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace FormGenerator.Handlers
{
    public class PropertyHandler : ContentHandler
    {
        public PropertyHandler(IRepository<Property> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}