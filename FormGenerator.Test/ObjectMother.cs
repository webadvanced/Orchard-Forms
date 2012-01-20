using FormGenerator.Models;
using FormGenerator.Models.Factories;
using FormGenerator.Models.VisualAppearance;

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
            return PropertyFactory.Create(BuildClass(), "Test Name", null, "Test Display Name", "Test Type",
                                          "Test Settings");
        }

        public static Class BuildClassWithProperties()
        {
            var dClass = new Class();
            dClass.Name = "Test Form";
            dClass.Properties.Add(PropertyFactory.Create(dClass,"TestName1",null,"Test Display Name1","TestType","none"));
            dClass.Properties.Add(PropertyFactory.Create(dClass, "TestName2", null, "Test Display Name2", "TestType", "none"));
            dClass.Properties.Add(PropertyFactory.Create(dClass, "TestName3", null, "Test Display Name3", "TestType", "none"));
            dClass.Properties.Add(PropertyFactory.Create(dClass, "TestName4", null, "Test Display Name4", "TestType1", "none"));
            dClass.Properties.Add(PropertyFactory.Create(dClass, "TestName5", null, "Test Display Name5", "TestType2", "none"));
            return dClass;
        }
            


    }
}