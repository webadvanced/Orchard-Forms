using System.Linq;
using System.Web.Mvc;
using FormGenerator.Models;
using FormGenerator.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Themes;

namespace FormGenerator.Controllers
{
    [Themed]
    public class FormController : Controller
    {
        private dynamic Shape { get; set; }
        private readonly IContentManager _contentManager;
        private readonly IOrchardServices _services;
        private readonly IDefinitionService _definitionService;
        public FormController(IContentManager contentManager, IOrchardServices services,IShapeFactory shapeFactory, IDefinitionService definitionService)
        {
            _contentManager = contentManager;
            _definitionService = definitionService;
            _services = services;
            Shape = shapeFactory;
        }

        public ActionResult Create()
        {
            //_definitionService.AddPropertyToClass(_contentManager.Query<FormPart>().List().First().Record, p =>
            //{
            //    p.Name = "ThirdTextBox";
            //    p.DisplayContext = new DisplayContext
            //    {
            //        Name = "Third Text Box",
            //        Type = "TextBox"
            //    };
            //    p.Settings = "";
            //});


            var form =_services.ContentManager.BuildEditor(_contentManager.Query<FormPart>().List().First());
            var list = Shape.List();
            list.Add(form);
            dynamic viewModel = Shape.ViewModel().ContentItems(list);
            return View((object)viewModel);
        }

        public ActionResult CreatePOST(int formId)
        {   
            return View();
        }
    }
}