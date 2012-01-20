using System;

namespace FormGenerator.Models.Factories
{
    public class ObjectFactory
    {
        public static Object Create(Class dClass)
        {
            var o = new Object();
            o.Class = dClass;            
            dClass.Properties.ForEach(property =>
                                          {
                                              var value = new Value();
                                              value.Object = o;
                                              value.Property = property;
                                              o.Values.Add(value);
                                          });
            return o;
        }
    }
}