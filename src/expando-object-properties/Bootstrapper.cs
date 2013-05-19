using System.ComponentModel;
using System.Dynamic;
using Machine.Specifications;

namespace JL
{
    public class Bootstrapper : IAssemblyContext
    {
        public void OnAssemblyStart()
        {
            // option 2
            //TypeDescriptor.AddProvider(new ExpandoObjectTypeDescriptionProvider(), typeof(ExpandoObject));
        }

        public void OnAssemblyComplete()
        {
        }
    }
}