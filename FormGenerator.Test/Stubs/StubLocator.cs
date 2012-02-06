using System;
using NHibernate;
using Orchard.Data;

namespace FormGenerator.Test.Stubs
{
    public class StubLocator : ISessionLocator
    {
        private readonly ISession _session;

        public StubLocator(ISession session)
        {
            _session = session;
        }

        #region ISessionLocator Members

        public ISession For(Type entityType)
        {
            return _session;
        }

        #endregion
    }
}