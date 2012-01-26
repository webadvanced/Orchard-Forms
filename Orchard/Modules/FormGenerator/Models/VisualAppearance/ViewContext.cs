using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Models.VisualAppearance
{
    public class ViewContext
    {
        public string Html { get; set; }
        public string Json { get; set; }
        public dynamic ShapeResult { get; set; }
        public string ShapeType { get; set; }
    }
}