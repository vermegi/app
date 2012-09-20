using Machine.Specifications;
using app.tasks.startup;
using app.utility.container;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(StartUp))]
  public class StartUpSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_run : concern
    {
      Because b = () =>
        StartUp.run();

      It should_configure_all_of_the_dependency_management = () =>
      {
        Dependencies.fetch.an<IProcessRequests>().ShouldBeAn<FrontController>();
      };
        
    }
  }
}
