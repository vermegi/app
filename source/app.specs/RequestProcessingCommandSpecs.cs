 using Machine.Specifications;
 using app.web;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(RequestProcessingCommand))]  
  public class RequestProcessingCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestProcessingCommand>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {
        private Establish c = () =>
        {
            thename = "RequestProcessing"; 
            
            request = fake.an<IEncapsulateRequestDetails>();
            request.setup(r => r.Name).Return(thename);
        };

        private Because b = () =>
                            result = sut.can_run(request);

        private It should_be_able_to_process_our_request = () =>
                                                           result.ShouldEqual(true);

        private static IEncapsulateRequestDetails request;
        private static bool result;
        private static IEncapsulateRequestDetails details;
        private static string thename;
    }
  }
}
