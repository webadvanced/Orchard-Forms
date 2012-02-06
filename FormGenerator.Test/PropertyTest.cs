using System;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using Xunit;

namespace FormGenerator.Test
{
    public class PropertyTest
    {
        //[Fact]
        //public void PropertyFactoryShouldBeAbleToValidateInupt()
        //{
        //    Assert.Throws<ApplicationException>(() => ObjectMother.BuildProperty(null, "TestName", null, "Test Display Name", "Test Type", "Test Settings"));
        //    Assert.Throws<ApplicationException>(() => ObjectMother.BuildProperty(new Class(), "", null, "Test Display Name", "Test Type", "Test Settings"));
        //    Assert.Throws<ApplicationException>(() => ObjectMother.BuildProperty(new Class(), "TestName", null, "", "Test Type", "Test Settings"));
        //    Assert.Throws<ApplicationException>(() => ObjectMother.BuildProperty(new Class(), "TestName", null, "Test Display Name", "", "Test Settings"));
        //    Assert.DoesNotThrow(() => ObjectMother.BuildProperty(new Class(), "TestName", null, "Test Display Name", "Test Type", "Test Settings"));
        //}

        [Fact]
        public void PropertyFactoryShouldSetDisplayContext()
        {
            var property = ObjectMother.BuildProperty(new Class(), "TestName", null, "Test Display Name", "Test Type",
                                                  "Test Settings");
            Assert.Equal("Test Display Name", property.DisplayContext.Name);
        }

    }
}