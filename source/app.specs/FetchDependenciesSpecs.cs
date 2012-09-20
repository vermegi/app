using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Container))]
  public class FetchDependenciesSpecs
  {
    public abstract class FetchDependenciesConcern : Observes<IFetchDependencies, Container>
    {
    }

    public class when_resolving_a_dependency : FetchDependenciesConcern
    {
      Establish c = () =>
      {
        configuration = depends.on<IConfigureAContainer>();
        implementer = new Implementer();
        configuration.setup(x => x.create<IAmAContract>()).Return(implementer);
      };

      Because b = () =>
        result = sut.an<IAmAContract>();

      It should_return_the_implementing_class = () =>
        result.ShouldEqual(implementer);

      static object result;
      static IConfigureAContainer configuration;
      static Implementer implementer;
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