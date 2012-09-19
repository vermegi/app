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
        renderer = depends.on<IDisplayReports>();
        department_repository = depends.on<IFindDepartments>();
        departments = new List<Department>();
        department_repository.setup(x => x.get_the_main_departments()).Return(departments);
      };

      Because b = () =>
        sut.run(request);

      It should_ask_the_renderer_to_show_the_departments = () =>
        renderer.received(x => x.display(departments));

      static IFindDepartments department_repository;
      static IEncapsulateRequestDetails request;
      static IDisplayReports renderer;
      static IEnumerable<Department> departments;
    }
  }
}