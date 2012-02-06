using System;
using System.Collections.Generic;
using System.Reflection;
using Orchard.Caching;
using Orchard.Environment.Extensions;
using Orchard.Environment.Extensions.Loaders;
using Orchard.Environment.Extensions.Models;
using Orchard.FileSystems.Dependencies;

namespace FormGenerator.Test.Stubs
{
    public class StubLoaders : IExtensionLoader
    {
        #region Implementation of IExtensionLoader

        public int Order
        {
            get { return 1; }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public Assembly LoadReference(DependencyReferenceDescriptor reference)
        {
            throw new NotImplementedException();
        }

        public void ReferenceActivated(ExtensionLoadingContext context, ExtensionReferenceProbeEntry referenceEntry)
        {
            throw new NotImplementedException();
        }

        public void ReferenceDeactivated(ExtensionLoadingContext context, ExtensionReferenceProbeEntry referenceEntry)
        {
            throw new NotImplementedException();
        }

        public bool IsCompatibleWithModuleReferences(ExtensionDescriptor extension, IEnumerable<ExtensionProbeEntry> references)
        {
            throw new NotImplementedException();
        }

        public ExtensionProbeEntry Probe(ExtensionDescriptor descriptor)
        {
            return new ExtensionProbeEntry { Descriptor = descriptor, Loader = this };
        }

        public IEnumerable<ExtensionReferenceProbeEntry> ProbeReferences(ExtensionDescriptor extensionDescriptor)
        {
            throw new NotImplementedException();
        }

        public ExtensionEntry Load(ExtensionDescriptor descriptor)
        {
            return new ExtensionEntry { Descriptor = descriptor, ExportedTypes = new[] { typeof(Alpha), typeof(Beta), typeof(Phi) } };
        }

        public void ExtensionActivated(ExtensionLoadingContext ctx, ExtensionDescriptor extension)
        {
            throw new NotImplementedException();
        }

        public void ExtensionDeactivated(ExtensionLoadingContext ctx, ExtensionDescriptor extension)
        {
            throw new NotImplementedException();
        }

        public void ExtensionRemoved(ExtensionLoadingContext ctx, DependencyDescriptor dependency)
        {
            throw new NotImplementedException();
        }

        public void Monitor(ExtensionDescriptor extension, Action<IVolatileToken> monitor)
        {
        }

        public IEnumerable<ExtensionCompilationReference> GetCompilationReferences(DependencyDescriptor dependency)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetVirtualPathDependencies(DependencyDescriptor dependency)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class Alpha
    {
    }

    public class Beta
    {
    }

    [OrchardFeature("TestFeature")]
    public class Phi
    {
    }
}