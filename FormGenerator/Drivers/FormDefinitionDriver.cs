using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FormGenerator.Models;
using FormGenerator.Services;
using FormGenerator.ViewModel;
using FormGenerator.VisualAppearance;
using JetBrains.Annotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using ViewContext = FormGenerator.VisualAppearance.ViewContext;

namespace FormGenerator.Drivers
{
    public class FormDefinitionDriver : ContentPartDriver<FormDefinitionPart>
    {
        private readonly IDisplayService _displayService;
        [NotNull] private readonly IEnumerable<IFieldHandler> _handlers;

        public FormDefinitionDriver(IDisplayService displayService, IEnumerable<IFieldHandler> handlers)
        {
            _displayService = displayService;
            _handlers = handlers;
        }

        protected override DriverResult Display(FormDefinitionPart part, string displayType, dynamic shapeHelper)
        {

            return Combined(
                ContentShape("EditorTemplates_FormDefinition",
                               () =>
                               shapeHelper.Parts_FormDefinition(
                               ContentPart: part,
                               TemplateName: "EditorTemplates/FormDefinition",
                               ContentItem: part.ContentItem,
                               Prefix: Prefix
                               ))
               );
        }


        [HttpGet]
        protected override DriverResult Editor(FormDefinitionPart part, dynamic shapeHelper)
        {
            if (part.ContentItem.IsPublished())
            {               
                var results = new List<DriverResult> {
                    ContentShape("Parts_FormDefinition_Edit", () =>
                        shapeHelper.EditorTemplate(
                        TemplateName: "Parts.FormDefinition.Edit",
                        Model: _displayService.GetFormDefinitionViewModel(part.Record),
                        Prefix: Prefix
                        )), 
                        ContentShape("FieldTypeList", () =>
                            shapeHelper.EditorTemplate(
                            TemplateName: "FieldTypeList",
                            Model: GetFieldTypes(), 
                            Prefix: Prefix))
                };
                var fieldViewContexts = (IEnumerable<ViewContext>)_displayService.GetFieldEditShapes(part.Record, shapeHelper);
                fieldViewContexts.ToList().ForEach(viewContext =>
                    results.Add((DriverResult)ContentShape(viewContext.ShapeType, () => viewContext.ShapeResult))
                    );

                return Combined(results.ToArray());
            }
            else
            {
                return null;
            }
        }
  

        protected override DriverResult Editor(FormDefinitionPart part, IUpdateModel updater, dynamic shapeHelper)
        {
           // var test = ((Controller)updater).Request.Form;
            var editorModel = new FormDefinitionViewModel(part.Record);
            updater.TryUpdateModel(editorModel, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        private Dictionary<string, List<string>> GetFieldTypes()
        {
            var fieldsDict = new Dictionary<string, List<string>>();
            foreach (var handler in _handlers)
            {
                var fieldType = handler.GetType().Name.Replace("Handler", String.Empty);
                if (!fieldsDict.ContainsKey(fieldType))
                {
                    fieldsDict[fieldType] = new List<string>();
                }
                fieldsDict[fieldType].Add(handler.GetType().Name.Replace("FieldHandler", ""));
            }

            return fieldsDict;
        }
    }
}