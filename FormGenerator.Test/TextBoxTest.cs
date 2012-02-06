using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FormGenerator.Models.Factories;
using FormGenerator.Models.VisualAppearance;
using FormGenerator.Services;
using FormGenerator.Test.Stubs;
using Moq;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;
using Orchard.Environment;
using Orchard.Environment.Extensions;
using Orchard.Environment.Extensions.Folders;
using Orchard.Environment.Extensions.Loaders;
using Orchard.Environment.Extensions.Models;
using Orchard.Security;
using Orchard.Tests.Stubs;
using Orchard.UI.Notify;
using Xunit;

namespace FormGenerator.Test
{
    public class TextBoxTest : DatabaseEnabledTestsBase
    {
        private readonly IDisplayService _displayService;

        public TextBoxTest()
        {
            _displayService = ObjectMother.GetDisplayService();
        }

        [Fact]
        public void PropertyWithTextBoxDisplayTypeShouldBeAbleToGenerateHtml()
        {
            var dClass = ObjectMother.BuildClass();
            dClass.Properties.Add(ObjectMother.BuildProperty(dClass, "TestName", null, "Test Display Name", "TextBox", ""));
            dynamic shapeBuilder = _container.Resolve<IShapeFactory>();
            ViewContext viewContext = _displayService.Display(dClass, shapeBuilder, "TestName");
            Assert.NotNull(viewContext.ShapeResult);
        }


        [Fact]
        public void PropertyWithTextBoxDisplayTypeShouldBeAbleToGenerateContentShapeResult()
        {
            var dClass = ObjectMother.BuildClass();
            dClass.Properties.Add(ObjectMother.BuildProperty(dClass, "TestName", null, "Test Display Name", "TextBox", ""));
            dynamic shapeBuilder = _container.Resolve<IShapeFactory>();
            ViewContext viewContext = _displayService.Display(dClass, shapeBuilder, "TestName");
            Assert.NotNull(viewContext.ShapeResult);
        }

        public override void Register(ContainerBuilder builder)
        {
            var features = new[] {
                new FeatureDescriptor {
                    Id = "Theme1",
                    Extension = new ExtensionDescriptor {
                        Id = "Theme1",
                        ExtensionType = DefaultExtensionTypes.Theme
                    }
                },
                new FeatureDescriptor {
                    Id = "DerivedTheme",
                    Extension = new ExtensionDescriptor {
                        Id = "DerivedTheme",
                        ExtensionType = DefaultExtensionTypes.Theme,
                        BaseTheme = "BaseTheme"
                    }
                },
                new FeatureDescriptor {
                    Id = "BaseTheme",
                    Extension = new ExtensionDescriptor {
                        Id = "BaseTheme",
                        ExtensionType = DefaultExtensionTypes.Theme
                    }
                }
            };
            var folders = new StubFolders();
            TestShapeProvider.FeatureShapes = new Dictionary<Feature, IEnumerable<string>> {
                { TestFeature(), new [] {"Hello"} },
                { Feature(features[0]), new [] {"Theme1Shape"} },
                { Feature(features[1]), new [] {"DerivedShape", "OverriddenShape"} },
                { Feature(features[2]), new [] {"BaseShape", "OverriddenShape"} }
            };
            builder.RegisterInstance(folders).As<IExtensionFolders>();
            builder.RegisterType<StubLoaders>().As<IExtensionLoader>();
            builder.RegisterType<StubAsyncTokenProvider>().As<IAsyncTokenProvider>();
        //    builder.RegisterType<StubExtensionManager>().As<IExtensionManager>();            
            builder.RegisterType<ExtensionManager>().As<IExtensionManager>();
            builder.RegisterType<StubCacheManager>().As<ICacheManager>();
            builder.RegisterType<StubParallelCacheContext>().As<IParallelCacheContext>();
            builder.RegisterType<DefaultContentManager>().As<IContentManager>();
        //    builder.RegisterType<DefaultContentManagerSession>().As<IContentManagerSession>();
         //   builder.RegisterInstance(new Mock<IContentDefinitionManager>().Object);
         //   builder.RegisterInstance(new Mock<ITransactionManager>().Object);
        //    builder.RegisterInstance(new Mock<IAuthorizer>().Object);
        //    builder.RegisterInstance(new Mock<INotifier>().Object);
         //   builder.RegisterInstance(new Mock<IContentDisplay>().Object);
            builder.RegisterType<OrchardServices>().As<IOrchardServices>();
            builder.RegisterType<DefaultShapeTableManager>().As<IShapeTableManager>();
            builder.RegisterType<DefaultShapeFactory>().As<IShapeFactory>();
            builder.RegisterType<ShapeTableLocator>().As<IShapeTableLocator>();

            builder.RegisterType<TestShapeProvider>().As<IShapeTableProvider>()
                .As<TestShapeProvider>()
                .InstancePerLifetimeScope();
         //   builder.RegisterType<ThingHandler>().As<IContentHandler>();

        //    builder.RegisterType<DefaultContentQuery>().As<IContentQuery>();
         //   builder.RegisterType<BodyPartHandler>().As<IContentHandler>();
        //    builder.RegisterType<StubExtensionManager>().As<IExtensionManager>();
          //  builder.RegisterType<DefaultContentDisplay>().As<IContentDisplay>();
        }

        static Feature Feature(FeatureDescriptor descriptor)
        {
            return new Feature
            {
                Descriptor = descriptor
            };
        }

        static Feature TestFeature()
        {
            return new Feature
            {
                Descriptor = new FeatureDescriptor
                {
                    Id = "Testing",
                    Dependencies = Enumerable.Empty<string>(),
                    Extension = new ExtensionDescriptor
                    {
                        Id = "Testing",
                        ExtensionType = DefaultExtensionTypes.Module,
                    }
                }
            };
        }
    }
    public class TestShapeProvider : IShapeTableProvider
    {
        public static IDictionary<Feature, IEnumerable<string>> FeatureShapes;

        public Action<ShapeTableBuilder> Discover = x => { };

        void IShapeTableProvider.Discover(ShapeTableBuilder builder)
        {
            foreach (var pair in FeatureShapes)
            {
                foreach (var shape in pair.Value)
                {
                    builder.Describe(shape).From(pair.Key).BoundAs(pair.Key.Descriptor.Id, null);
                }
            }
            Discover(builder);
        }
    }
}