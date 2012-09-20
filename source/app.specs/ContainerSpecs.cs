using System;
using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies, Container>
    {
    }

    public class when_resolving_a_dependency : concern
    {
      public class and_it_has_the_factory_to_create_the_dependency
      {
        Establish c = () =>
        {
          factories = depends.on<IFindFactoriesForDependencies>();
          factory = fake.an<ICreateOneDependency>();
          implementer = new Implementer();
          factories.setup(x => x.get_factory_that_can_create(typeof(IAmAContract))).Return(factory);
          factory.setup(x => x.create()).Return(implementer);
        };

        Because b = () =>
          result = sut.an<IAmAContract>();

        It should_return_the_dependency_created_by_the_factory_that_can_create_it = () =>
          result.ShouldEqual(implementer);

        static object result;
        static IFindFactoriesForDependencies factories;
        static Implementer implementer;
        static ICreateOneDependency factory;
      }

      public class and_the_factory_that_creates_the_dependency_throws_an_error_on_creation
      {
        Establish c = () =>
        {
          an_exception = new Exception();
          the_created_exception = new Exception();
          factories = depends.on<IFindFactoriesForDependencies>();
          factory = fake.an<ICreateOneDependency>();
          factories.setup(x => x.get_factory_that_can_create(typeof(IAmAContract))).Return(factory);
          factory.setup(x => x.create()).Throw(an_exception);

          depends.on<DependencyCreationExceptionFactory_Behaviour>((x,inner) =>
          {
            x.ShouldEqual(typeof(IAmAContract));
            inner.ShouldEqual(an_exception);
            return the_created_exception;
          });
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<IAmAContract>());

        It should_throw_the_created_dependency_creation_exception = () =>
          spec.exception_thrown.ShouldEqual(the_created_exception);

        static IFindFactoriesForDependencies factories;
        static ICreateOneDependency factory;
        static Exception the_created_exception;
        static Exception an_exception;
      }
    }

    internal class Implementer : IAmAContract
    {
    }

    internal interface IAmAContract
    {
    }
  }

  interface IConfigureAContainer
  {
    T create<T>();
  }
}