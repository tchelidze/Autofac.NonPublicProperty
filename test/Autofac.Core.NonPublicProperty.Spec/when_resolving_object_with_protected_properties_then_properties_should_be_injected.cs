using Machine.Specifications;
using Shouldly;
using System.Reflection;

namespace Autofac.Core.NonPublicProperty.Spec
{
    public class when_resolving_object_with_protected_properties_then_properties_should_be_injected
    {
        static IContainer _container;
        static ClassWithInternalDependencies _classWithInternalDependencies;

        Establish context = () =>
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder
                .RegisterType<Dependency1>()
                .As<IDependency1>();

            containerBuilder
                .RegisterType<ClassWithInternalDependencies>()
                .AsSelf()
                .AutoWireNonPublicProperties();

            _container = containerBuilder.Build();
        };

        Because of = () => _classWithInternalDependencies = _container.Resolve<ClassWithInternalDependencies>();

        It should_inject_IDependency1 =
            () =>
            {
                typeof(ClassWithInternalDependencies)
                    .GetProperty("DependencyOne", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(_classWithInternalDependencies)
                    .ShouldNotBeNull();
            };

        public class ClassWithInternalDependencies
        {
            protected IDependency1 DependencyOne { get; set; }
        }

        public interface IDependency1
        {
        }

        public class Dependency1 : IDependency1
        {
        }
    }
}