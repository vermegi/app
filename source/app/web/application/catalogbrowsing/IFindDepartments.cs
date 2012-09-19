using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<Department> get_the_main_departments();
    IEnumerable<Department> get_the_departments_for(DepartmentsInADepartmentRequest request);
  }
}