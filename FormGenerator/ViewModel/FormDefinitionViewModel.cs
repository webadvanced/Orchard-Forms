using System.Collections.Generic;
using System.Linq;
using FormGenerator.Models;
using FormGenerator.ViewModel.PropertyViewModels;

namespace FormGenerator.ViewModel {
    public class FormDefinitionViewModel {
        public FormDefinitionViewModel() {         
            Textboxes = new List<TextboxViewModel>();
        }

        public FormDefinitionViewModel(Class dClass) {
            Id = dClass.Id;
            Textboxes = new List<TextboxViewModel>();
            Class = dClass;
        }

        public int Id { get; set; }        
        public List<TextboxViewModel> Textboxes { get; set; }
        public Class Class { get; private set; }
    }
}
