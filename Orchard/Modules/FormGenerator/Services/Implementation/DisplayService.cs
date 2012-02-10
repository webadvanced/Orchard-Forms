using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FormGenerator.Models;
using FormGenerator.ViewModel;
using FormGenerator.VisualAppearance;
using Object = FormGenerator.Models.Object;

namespace FormGenerator.Services.Implementation
{
    public class DisplayService : IDisplayService
    {

        private readonly IFieldHandlerService _fieldHandlerService;

        public DisplayService(IFieldHandlerService fieldHandlerService)
        {
            _fieldHandlerService = fieldHandlerService;
        }

        public ViewContext Display(Class dClass, dynamic shapeHelper, string propertyName)
        {
            var viewContext = new ViewContext();
            var property = dClass.Properties.Single(p => p.Name == propertyName);
            var derivedTypes = TypesImplementingInterface(typeof(IFieldHandler));
            derivedTypes.ToList().ForEach(ct =>
                                              {
                                                  ConstructorInfo ci = ct.GetConstructor(new Type[] { });
                                                  var instance = ci.Invoke(new Object[] { });
                                                  ct.GetMethod("DisplayValue").Invoke(instance, new object[] { property, viewContext, shapeHelper });
                                              });
            return viewContext;
        }

        public void Editor(Class dClass)
        {
            throw new NotImplementedException();
        }

        public void Process(Object o)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllFieldTypes()
        {
            var derivedTypes = TypesImplementingInterface(typeof(IFieldHandler));
            var list = new List<string>();
            derivedTypes.ToList().ForEach(t => list.Add(t.Name.Replace("Handler", "")));
            return list;
        }


        public IEnumerable<ViewContext> GetFieldEditShapes(Class dClass, dynamic shapeHelper)
        {
            var result = new List<ViewContext>();
            var index = 0;
            foreach (var property in dClass.Properties)
            {
                var handler = _fieldHandlerService.GetFieldHandler(property.DisplayContext.Type);
                if (handler != null)
                {
                    var viewContext = new ViewContext();
                    handler.DisplayProperty(property, viewContext, shapeHelper, index);
                    result.Add(viewContext);
                    index++;
                    //field.SettingsTemplate = handler.Editor(field._Definition.Settings);
                }
            }
            return result;
        }

        public FormDefinitionViewModel GetFormDefinitionViewModel(Class dClass)
        {
            var model = new FormDefinitionViewModel();
            for (int i = 0; i < dClass.Properties.Count; i++)
            {
                _fieldHandlerService.GetFieldHandler(dClass.Properties[i]).AddViewModel(model,dClass.Properties[i] ,i);
            }
            return model;
        }

        private IEnumerable<Type> TypesImplementingInterface(Type desiredType)
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => desiredType.IsAssignableFrom(type) && !type.IsInterface);

        }      
    }
}