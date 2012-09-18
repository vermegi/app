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
        
      It first_observation = () =>        
        
    }
  }
}
