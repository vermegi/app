using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore : ISupportAUserFeature
  {
    IFindDepartments department_repository;

    public ViewTheMainDepartmentsInTheStore(IFindDepartments department_repository)
    {
      this.department_repository = department_repository;
    }

    public void run(IEncapsulateRequestDetails request)
    {
      department_repository.get_the_main_departments();
    }
  }
}