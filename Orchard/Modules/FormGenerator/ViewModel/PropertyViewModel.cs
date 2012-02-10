using System.ComponentModel.DataAnnotations;
using FormGenerator.Models;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace FormGenerator.ViewModel {
    public class PropertyViewModel {
        public PropertyViewModel() {
            Settings = new SettingsDictionary();
        }

        public PropertyViewModel(int index, Property property) {
            Index = index;
            Settings = new SettingsDictionary();
            Name = property.Name;
            Type = property.DisplayContext.Type;
            Label = property.DisplayContext.Name;
            Weight = property.DisplayContext.Weight;
            Property = property;
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public virtual string Prefix { get { return "Fields[" + Index + "]"; } }
        public int Weight { get; set; }
        public SettingsDictionary Settings { get; set; }
        public TemplateViewModel SettingsTemplate { get; set; }
        public Property Property { get; private set; }
    }
}
