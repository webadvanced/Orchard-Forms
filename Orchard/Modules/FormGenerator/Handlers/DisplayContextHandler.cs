using FormGenerator.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace FormGenerator.Handlers
{
    public class DisplayContextHandler : ContentHandler
    {
        public DisplayContextHandler(IRepository<DisplayContext> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}