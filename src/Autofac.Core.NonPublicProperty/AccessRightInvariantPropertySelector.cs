using System.Reflection;

namespace Autofac.Core.NonPublicProperty
{
    public class AccessRightInvariantPropertySelector : DefaultPropertySelector
    {
        public AccessRightInvariantPropertySelector(bool preserveSetValues) : base(preserveSetValues)
        { }

        public override bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            if (!propertyInfo.CanWrite)
            {
                return false;
            }

            if (!PreserveSetValues || !propertyInfo.CanRead)
            {
                return true;
            }

            try
            {
                return propertyInfo.GetValue(instance, null) == null;
            }
            catch
            {
                // Issue #799: If getting the property value throws an exception
                // then assume it's set and skip it.
                return false;
            }
        }
    }
}