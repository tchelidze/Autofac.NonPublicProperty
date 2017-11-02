# Autofac.NonPublicProperty - Enable non public property injection

# [Nuget](https://www.nuget.org/packages/Autofac.Core.NonPublicProperty)

   `PM> Install-Package Autofac.Core.NonPublicProperty`

# Features

 - [internal property injection](https://github.com/tchelidze/Autofac.NonPublicProperty/blob/master/test/Autofac.Core.NonPublicProperty.Spec/when_resolving_object_with_internal_properties_then_properties_should_be_injected.cs)
 - [protected property injection](https://github.com/tchelidze/Autofac.NonPublicProperty/blob/master/test/Autofac.Core.NonPublicProperty.Spec/when_resolving_object_with_protected_properties_then_properties_should_be_injected.cs)
 
# Example 

```
public interface IService
{}

public class Foo
{
   protected IService Service { get; set; }
}

 ...

containerBuilder
   .RegisterType<Foo>()
   .AsSelf()
   .AutoWireNonPublicProperties();
```
 
