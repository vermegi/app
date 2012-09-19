using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsInADepartment))]
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature, ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        departmentname = "a name";
        request = fake.an<IEncapsulateRequestDetails>();
        new_request = new DepartmentsInADepartmentRequest();
        renderer = depends.on<IDisplayReports>();
        department_repository = depends.on<IFindDepartments>();
        departments = new List<Department>();

        request.setup(r => r.map<DepartmentsInADepartmentRequest>()).Return(new_request);
        department_repository.setup(x => x.get_the_departments_for(new_request)).Return(departments);
      };

      Because b = () =>
        sut.run(request);

      It should_ask_the_renderer_to_show_the_departments = () =>
        renderer.received(x => x.display(departments));

      static IFindDepartments department_repository;
      static IEncapsulateRequestDetails request;
      static IDisplayReports renderer;
      static IEnumerable<Department> departments;
      static string departmentname;
      static DepartmentsInADepartmentRequest new_request;
    }
  }
}