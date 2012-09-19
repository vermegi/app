using System.Collections.Generic;
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
          department_repository.setup(x => x.get_the_main_departments()).Return(departments);
      };

      Because b = () =>
        sut.run(request);

      It should_get_the_main_departments = () =>
        department_repository.received(x => x.get_the_main_departments());

        private It should_ask_the_renderer_to_show_the_departments = () =>
                                                                     renderer.received(x => x.display(departments));

      static IFindDepartments department_repository;
      static IEncapsulateRequestDetails request;
        private static IRenderDepartments renderer;
        private static IEnumerable<Department> departments;
    }
  }
}