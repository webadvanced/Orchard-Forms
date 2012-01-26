using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FormGenerator.Models;

namespace FormGenerator.Map
{
    public class PropertyMap : IAutoMappingOverride<Property> 

    {
        public void Override(AutoMapping<Property> mapping)
        {
            mapping.IgnoreProperty(x => x.ValidationRules);
        } 

    }
}