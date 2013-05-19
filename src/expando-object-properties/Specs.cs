using System.ComponentModel;
using System.Dynamic;
using Machine.Specifications;
using FluentAssertions;

namespace JL
{
    [Subject(typeof(ExpandoObject), "when enumerating properties via TypeDescriptor.GetProperties")]
    public class with_two_dynamic_properties
    {
        Establish context = () =>
        {
            Dynamic = new ExpandoObject();
            Dynamic.Foo = 0;
            Dynamic.Bar = "Bar";

            // option 1
            //TypeDescriptor.AddProvider(new ExpandoObjectTypeDescriptionProvider(), Dynamic);
        };

        Because of = () => Properties = TypeDescriptor.GetProperties(Dynamic); 

        It should_find_the_dynamic_properties = () =>
        {
            Properties.Count
                      .Should()
                      .Be(2);
        };

        static dynamic Dynamic;
        static PropertyDescriptorCollection Properties;
    }
}