using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        department_repository = depends.on<IFindDepartments>();
      };

      Because b = () =>
        sut.run(request);

      It should_get_the_main_departments = () =>
        department_repository.received(x => x.get_the_main_departments());

      static IFindDepartments department_repository;
      static IEncapsulateRequestDetails request;
    }
  }
}