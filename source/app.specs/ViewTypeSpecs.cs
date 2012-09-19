using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewType))]
  public class ViewTypeSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature, ViewType<DepartmentsInADepartmentRequest, IEnumerable<Department>>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        new_request = new DepartmentsInADepartmentRequest();
        renderer = depends.on<IDisplayReports>();
        finder = depends.on<IFind>();
        departments = new List<Department>();

        request.setup(r => r.map<DepartmentsInADepartmentRequest>()).Return(new_request);
        finder.setup(x => x.find<DepartmentsInADepartmentRequest, IEnumerable<Department>>(new_request)).Return(departments);
      };

      Because b = () =>
        sut.run(request);

      It should_ask_the_renderer_to_show_the_departments = () =>
        renderer.received(x => x.display(departments));

      static IFind finder;
      static IEncapsulateRequestDetails request;
      static IDisplayReports renderer;
      static IEnumerable<Department> departments;
      static DepartmentsInADepartmentRequest new_request;
    }
  }
}