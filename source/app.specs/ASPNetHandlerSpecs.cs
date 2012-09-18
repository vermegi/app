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

   
    public class when_processing_and_http_context : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateControllerRequests>();
        a_created_request = fake.an<IEncapsulateRequestDetails>();
        an_context = ObjectFactory.web.create_http_context();

        request_factory.setup(x => x.create_request_from(an_context)).Return(a_created_request);
      };

      Because b = () =>
        sut.ProcessRequest(an_context);

      It should_delegate_The_processing_of_AN_Ew_controller_request_TOT_HE_front_controller = () =>
        front_controller.received(x => x.process(a_created_request));

      static IProcessRequests front_controller;
      static IEncapsulateRequestDetails a_created_request;
      static HttpContext an_context;
      static ICreateControllerRequests request_factory;
    }
  }
}
