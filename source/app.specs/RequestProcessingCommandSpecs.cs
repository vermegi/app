using Machine.Specifications;
using app.web;
using app.web.core;
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
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        depends.on<RequestMatch_Behaviour>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_run(request);

      It should_make_its_decision_by_leveraging_its_request_specfiication = () =>
        result.ShouldBeTrue();

      static IEncapsulateRequestDetails request;
      static bool result;
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        application_feature = depends.on<ISupportAUserFeature>();
        request = fake.an<IEncapsulateRequestDetails>();
      };

      Because b = () =>
        sut.run(request);

      It should_dispatch_to_the_application_Feature = () =>
        application_feature.received(x => x.run(request));

      static IEncapsulateRequestDetails request;
      static ISupportAUserFeature application_feature;
    }
  }
}