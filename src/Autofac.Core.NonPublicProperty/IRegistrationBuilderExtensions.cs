using Autofac.Builder;

namespace Autofac.Core.NonPublicProperty
{
    public static class IRegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle>
            AutoWireNonPublicProperties<TLimit, TActivatorData, TRegistrationStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder,
                bool preserveSetValues = true,
                bool allowCircularDependencies = false)
            => registrationBuilder
                .PropertiesAutowired(new AccessRightInvariantPropertySelector(preserveSetValues), allowCircularDependencies);
    }
}