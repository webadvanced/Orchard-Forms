using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FormGenerator.Models;
using FormGenerator.Services;
using FormGenerator.ViewModel.PropertyViewModels;
using FormGenerator.VisualAppearance;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Contents.Controllers;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Notify;
using FormGenerator.ViewModel;

namespace FormGenerator.Controllers
{
    public class AdminController : Controller, IUpdateModel
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IFieldHandlerService _fieldHandlerService;
        public Localizer T { get; set; }

        public AdminController(IOrchardServices orchardServices, IFieldHandlerService fieldHandlerService)
        {
            _orchardServices = orchardServices;
            _fieldHandlerService = fieldHandlerService;            
            T = NullLocalizer.Instance;
        }

        public ActionResult Index()
        {
            var formList = _orchardServices.ContentManager.Query<FormDefinitionPart>(VersionOptions.Published, "FormDefinition").List().ToList();
            return View(formList);
        }

        public ActionResult Edit(int formId)
        {
            var formItem = _orchardServices.ContentManager.Get(formId);
            if (formItem != null)
            {
                dynamic model = _orchardServices.ContentManager.BuildEditor(formItem);
                return View((object)model);
            }
            return HttpNotFound();
        }


        [HttpPost, ActionName("Edit")]
        [FormValueRequired("submit.Save")]
        public ActionResult EditPOST(int formId)
        {
            var form = _orchardServices.ContentManager.Get(formId);
            if (form == null)
                return HttpNotFound();

            dynamic model = _orchardServices.ContentManager.UpdateEditor(form, this);

            // We now have a fully populated model including all field-sepcific settings objects
            // Check the model state to see if anything threw an error
            if (!ModelState.IsValid)
            {
                _orchardServices.TransactionManager.Cancel();
                // Casting to avoid invalid (under medium trust) reflection over the protected View method and force a static invocation.
                return View((object)model);
            }

            _orchardServices.ContentManager.Publish(form);
            _orchardServices.Notifier.Information(T("Form saved"));

            return RedirectToAction("Index");
        }

        [Themed(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetFieldEditor(string handler)
        {
            var result = _fieldHandlerService.GetFieldHandler(handler);  
            var model = result.ViewModel;
            var view = result.ViewAddress;
            return View(view, model);
        }

        #region IUpdateModel
        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties)
        {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage)
        {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
        #endregion
        
    }
}