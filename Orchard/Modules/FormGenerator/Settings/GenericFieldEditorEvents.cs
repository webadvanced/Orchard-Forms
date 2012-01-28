using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace FormGenerator.Field.Settings
{
    public class GenericFieldEditorEvents : ContentDefinitionEditorEventsBase
    {
        public override IEnumerable<TemplateViewModel> PartFieldEditor(ContentPartFieldDefinition definition)
        {
            if (definition.FieldDefinition.Name == "GenericFieldSettings")
            {
                var model = definition.Settings.GetModel<GenericFieldSettings>();
                yield return DefinitionTemplate(model);
            }
        }

        public override IEnumerable<TemplateViewModel> PartFieldEditorUpdate(ContentPartFieldDefinitionBuilder builder, IUpdateModel updateModel)
        {
            
            var model = new GenericFieldSettings();
            if (updateModel.TryUpdateModel(model, "GenericFieldSettings", null, null))
            {
                builder.WithSetting("GenericFieldSettings.MaxLength", model.MaxLength);
            }

            yield return DefinitionTemplate(model);
        }
    }
}