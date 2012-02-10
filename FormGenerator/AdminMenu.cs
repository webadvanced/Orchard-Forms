using Orchard.Localization;
using Orchard.UI.Navigation;

namespace FormGenerator
{
    public class AdminMenu : INavigationProvider
    {
        public Localizer T { get; set; }

        public AdminMenu()
        {
            T = NullLocalizer.Instance;
        }

        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Form Builder"), "6",
                menu => menu.Add(T("Form List"), "0", item => item.Action("Index", "Admin", new { area = "FormGenerator" })));
        }
    }
}
