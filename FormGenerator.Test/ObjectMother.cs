using System;
using System.Collections.Generic;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using FormGenerator.Models.Validation;
using FormGenerator.Services;
using FormGenerator.Services.Implementation;

namespace FormGenerator.Test
{
    public static class ObjectMother
    {
        public static Class BuildClass()
        {
            return new Class()
                       {
                           Name = "Test Class Name",
                           DefaultEmail = "test@test.test"
                       };
        }

        public static Property BuildProperty()
        {
            var property = new Property
            {
                Class = BuildClass(),
                Name = "Test Property",
                Settings = "",                
                ValidationRules = null,
                DisplayContext = new DisplayContext
                                     {
                                         Name = "Test Display Name",
                                         Type = "Test Display Type"
                                     }
            };
            return property;
        }



        public static Property BuildProperty(Class dClass, string name, IEnumerable<IValidationRule> validationRules, string displayName, string displayType, string setttings)
        {
            var property = new Property
            {
                Class = dClass,
                Name = name,
                Settings = setttings,                
                ValidationRules = validationRules,
                DisplayContext = new DisplayContext
                {
                    Name = displayName,
                    Type = displayType
                }
            };
            return property;
        }


        public static Class BuildClassWithProperties()
        {
            var dClass = new Class();
            dClass.Name = "Test Form";
            dClass.Properties.Add(BuildProperty(dClass, "TestName1", null, "Test Display Name1", "TestDisplayType", "none"));
            dClass.Properties.Add(BuildProperty(dClass, "TestName2", null, "Test Display Name2", "TestDisplayType", "none"));
            dClass.Properties.Add(BuildProperty(dClass, "TestName3", null, "Test Display Name3", "TestDisplayType", "none"));
            dClass.Properties.Add(BuildProperty(dClass, "TestName4", null, "Test Display Name4", "TestDisplayType1", "none"));
            dClass.Properties.Add(BuildProperty(dClass, "TestName5", null, "Test Display Name5", "TestDisplayType2", "none"));
            return dClass;
        }


        public static IDisplayService GetDisplayService()
        {
            return new DisplayService(null);
        }
    }
}