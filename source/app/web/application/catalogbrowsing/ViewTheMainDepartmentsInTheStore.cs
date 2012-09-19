using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore : ISupportAUserFeature
  {
    IFindDepartments department_repository;
    IDisplayReports department_display;

    public ViewTheMainDepartmentsInTheStore(IFindDepartments department_repository, IDisplayReports department_display)
    {
      this.department_repository = department_repository;
      this.department_display = department_display;
    }

    public ViewTheMainDepartmentsInTheStore():this(new StubDepartmentRepository(),
      new StubDisplayEngine())
    {
    }

    public void run(IEncapsulateRequestDetails request)
    {
      department_display.display(department_repository.get_the_main_departments());
    }
  }
}