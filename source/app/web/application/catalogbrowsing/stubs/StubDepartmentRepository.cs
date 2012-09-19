﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubDepartmentRepository : IFindDepartments
  {
    public IEnumerable<Department> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
    }

    public IEnumerable<Department> get_the_departments_for(DepartmentsInADepartmentRequest request)
    {
      return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Sub Department 0")});
    }
  }
}