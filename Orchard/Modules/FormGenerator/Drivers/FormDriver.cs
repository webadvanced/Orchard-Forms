using FormGenerator.Models;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Drivers
{
    public class FormDriver : ContentPartDriver<FormPart>
    {
        protected override DriverResult Display(FormPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                ContentShape("Parts_Form",
                               () =>
                               shapeHelper.Parts_Form(
                               ContentPart: part,
                               TemplateName: "Parts/Form",
                               ContentItem: part.ContentItem,
                               Prefix: Prefix
                               ))
               );
        }
    }
}