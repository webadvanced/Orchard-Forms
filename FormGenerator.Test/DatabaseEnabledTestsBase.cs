using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autofac;
using FormGenerator.Test.Stubs;
using NHibernate;
using Orchard.Data;
using Orchard.Services;
using Xunit;

namespace FormGenerator.Test
{
    public abstract class DatabaseEnabledTestsBase : IDisposable
    {

        protected IContainer _container;

        protected ISession _session;
        protected string _databaseFilePath;
        protected ISessionFactory _sessionFactory;
        protected StubClock _clock;

        public DatabaseEnabledTestsBase()
        {
            Init();
        }


        [Fact]
        public void InitFixture()
        {
        }

        [Fact]
        public void TearDownFixture()
        {
            File.Delete(_databaseFilePath);
        }

        public virtual void Init()
        {
            _databaseFilePath = Path.GetTempFileName();
            _sessionFactory = DataUtility.CreateSessionFactory(_databaseFilePath, DatabaseTypes.ToArray());
            _session = _sessionFactory.OpenSession();
            _clock = new StubClock();

            var builder = new ContainerBuilder();
            //builder.RegisterModule(new ImplicitCollectionSupportModule());
            builder.RegisterInstance(new StubLocator(_session)).As<ISessionLocator>();
            builder.RegisterInstance(_clock).As<IClock>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            Register(builder);
            _container = builder.Build();
        }

        public void Cleanup()
        {
            if (_container != null)
                _container.Dispose();

            if (_session != null)
                _session.Close();
        }

        public abstract void Register(ContainerBuilder builder);

        protected virtual IEnumerable<Type> DatabaseTypes
        {
            get
            {
                return Enumerable.Empty<Type>();
            }
        }

        protected void ClearSession()
        {
            Trace.WriteLine("Flush and clear session");
            _session.Flush();
            _session.Clear();
            Trace.WriteLine("Flushed and cleared session");
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}