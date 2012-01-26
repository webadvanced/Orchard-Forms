using System.Collections.Generic;
using System.Linq;
using FormGenerator.Models.Factories;
using FormGenerator.Models.Validation;
using Xunit;

namespace FormGenerator.Test
{
    public class ObjectTest
    {
        //[Fact]
        //public void ObjectFactoryShouldBeAbleToCreateNewObjectFromExistingClass()
        //{
        //    var dClass = ObjectMother.BuildClassWithProperties();
        //    var o = ObjectFactory.Create(dClass);
        //    Assert.NotNull(o);
        //    var propertiesCount = dClass.Properties.Count;
        //    Assert.Equal(propertiesCount,o.Values.Count);
        //    o.Values.ToList().ForEach(value =>
        //                         {
        //                             Assert.NotNull(value.Property);
        //                             Assert.NotNull(value.Object);
        //                             Assert.Null(value.value);
        //                         });
        //}

        //[Fact]
        //public void ObjectShouldBeAbleToValidateItself()
        //{
        //    var dClass = ObjectMother.BuildClass();
        //    var validationRules = new List<IValidationRule>();
        //    validationRules.Add(new NumberValidationRule());
        //    dClass.Properties.Add(PropertyFactory.Create(dClass,"TestName",validationRules,"Number","Number",""));
        //    var o = ObjectFactory.Create(dClass);
        //    var value = o.Values.ToList().First();
        //    value.value = "Test string value";
        //    Assert.False(value.Validate());
        //    Assert.NotNull(value.ValidationMessage);
        //}
    }
}