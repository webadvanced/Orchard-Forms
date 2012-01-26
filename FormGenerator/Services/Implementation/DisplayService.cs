using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FormGenerator.Models;
using FormGenerator.Models.VisualAppearance;
using Object = FormGenerator.Models.Object;

namespace FormGenerator.Services.Implementation
{
    public class DisplayService : IDisplayService
    {
        public IEnumerable<ViewContext> Display(Class dClass, dynamic shapeHelper)
        {
            var list = new List<ViewContext>();

            var derivedTypes = TypesImplementingInterface(typeof(IAppearanceHandler));
            derivedTypes.ToList().ForEach(ct =>
                                              {
                                                  dClass.Properties.ToList().ForEach(property =>
                                                  {
                                                      var viewContext = new ViewContext();
                                                      ConstructorInfo ci = ct.GetConstructor(new Type[] { });
                                                      var instance = ci.Invoke(new Object[] { });
                                                      ct.GetMethod("Display").Invoke(instance, new object[] { property, viewContext, shapeHelper });
                                                      if (viewContext.ShapeResult != null)
                                                      {
                                                          list.Add(viewContext);
                                                      }
                                                  });
                                              });
            return list;
        }

        public void Editor(Class dClass)
        {
            throw new NotImplementedException();
        }

        public void Process(Object o)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Type> TypesImplementingInterface(Type desiredType)
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => desiredType.IsAssignableFrom(type) && !type.IsInterface);

        }
    }
}