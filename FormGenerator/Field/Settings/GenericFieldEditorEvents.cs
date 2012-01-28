using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;
using System.Reflection;

namespace FormGenerator.Field.Settings
{
    public class GenericFieldEditorEvents : ContentDefinitionEditorEventsBase
    {
        public override IEnumerable<TemplateViewModel> PartFieldEditor(ContentPartFieldDefinition definition)
        {
            if (definition.FieldDefinition.Name == "GenericField")
            {
                var model = definition.Settings.GetModel<GenericFieldSettings>();
                yield return DefinitionTemplate(model);
            }
        }

        public override IEnumerable<TemplateViewModel> PartFieldEditorUpdate(ContentPartFieldDefinitionBuilder builder, IUpdateModel updateModel)
        {
            var t = updateModel.GetType();
            var y = t.InvokeMember("_thunk", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, updateModel, new object[] { });
            var model = (FieldUpdateModel)y;
            if (builder.Name == model.FieldName)
            {
                builder.WithSetting("GenericFieldSettings.MaxLength", model.Settings.MaxLength);
            }
            yield return DefinitionTemplate(model);
        }
    }
}