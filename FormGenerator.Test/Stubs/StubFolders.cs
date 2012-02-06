using System.Collections.Generic;
using Orchard.Environment.Extensions.Folders;
using Orchard.Environment.Extensions.Models;

namespace FormGenerator.Test.Stubs
{
    public class StubFolders : IExtensionFolders
    {
        public StubFolders()
        {
            Manifests = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Manifests { get; set; }

        public IEnumerable<ExtensionDescriptor> AvailableExtensions()
        {
            foreach (var e in Manifests)
            {
                string name = e.Key;
                yield return ExtensionHarvester.GetDescriptorForExtension("~/", name, DefaultExtensionTypes.Module, Manifests[name]);
            }
        }
    }
}