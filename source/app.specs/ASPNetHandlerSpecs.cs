 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ASPNetHandler))]  
  public class ASPNetHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      ASPNetHandler>
    {
        
    }

    public class when_processing_an_http_context : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateControllerRequests>();
        a_created_request = new object();
        an_context = ObjectFactory.web.create_http_context();

        request_factory.setup(x => x.create_request_from(an_context)).Return(a_created_request);
      };

      Because b = () =>
        sut.ProcessRequest(an_context);

      It should_delegate_the_processing_of_a_new_controller_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(a_created_request));

      static IProcessRequests front_controller;
      static object a_created_request;
      static HttpContext an_context;
      static ICreateControllerRequests request_factory;
    }
  }
}
