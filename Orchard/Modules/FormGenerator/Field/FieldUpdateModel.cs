using System;
using FormGenerator.Field.Settings;
using Orchard.ContentManagement;
using Orchard.Localization;

namespace FormGenerator.Field
{
    public class FieldUpdateModel : IUpdateModel
    {

        public bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) where TModel : class
        {

            return true;
        }

        public void AddModelError(string key, LocalizedString errorMessage)
        {
            throw new NotImplementedException();
        }

        public ValueGenericFieldSettings Settings { get; set; }
        public string FieldName { get; set; }
    }
}