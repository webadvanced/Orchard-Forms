namespace FormGenerator.Models.VisualAppearance
{
    public interface IAppearanceHandler
    {
        IAppearanceHandler Next { get; set; }
        void Process(Object o);
        dynamic Editor(Class dClass);
        dynamic Display(Class dClass);
    }
}