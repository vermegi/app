using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Dependencies))]
  public class DependenciesSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_providing_access_to_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IFetchDependencies>();
        GetTheActiveContainer_Behaviour resolution = () => the_container_facade;
        spec.change(() => Dependencies.container_resolver).to(resolution);
      };
      Because b = () =>
        result = Dependencies.fetch;

      It should_return_the_container_facade_it_was_configured_to_return = () =>
        result.ShouldEqual(the_container_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_container_facade;
    }
  }
}
