using Machine.Specifications;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayReports,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_a_report : concern
    {
      Establish c = () =>
      {
        the_report = new SomeItemToDisplay();
        page_factory = depends.on<ICreateDisplayHandlers>();
      };

      Because b = () =>
        sut.display(the_report);

      It should_create_the_handler_that_can_display_the_report = () =>
        page_factory.received(x => x.create_handler_to_display(the_report));

      static ICreateDisplayHandlers page_factory;
      static SomeItemToDisplay the_report;
    }

    public class SomeItemToDisplay
    {
    }
  }
}