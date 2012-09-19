using System.Web;
using Machine.Specifications;
using app.specs.utility;
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
        the_page = fake.an<IHttpHandler>();
        page_factory = depends.on<ICreateDisplayHandlers>();
        the_current_context = ObjectFactory.web.create_http_context();
        page_factory.setup(x => x.create_handler_to_display(the_report)).Return(the_page);

        depends.on(the_current_context);
      };

      Because b = () =>
        sut.display(the_report);

      It should_create_the_handler_that_can_display_the_report = utility.spec.comment;

      It should_tell_the_handler_to_Execute_using_the_current_Context = () =>
        the_page.received(x => x.ProcessRequest(the_current_context));
        


      static ICreateDisplayHandlers page_factory;
      static SomeItemToDisplay the_report;
      static IHttpHandler the_page;
      static HttpContext the_current_context;
    }

    public class SomeItemToDisplay
    {
    }
  }
}