using System.ComponentModel.DataAnnotations;
using FormGenerator.Models;

namespace FormGenerator.ViewModel.PropertyViewModels
{
    public class TextboxViewModel : PropertyViewModel
    {
        public TextboxViewModel()
        {
            
        }
        public TextboxViewModel(int index, Property property) : base(index,property)
        {            
        }
        [Display(Name = "Maximum Input Length")]
        public int? MaxLength { get; set; }

        public override string Prefix { get { return "Textboxes[" + Index + "]"; } }
    }
}
