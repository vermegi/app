using System;
using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return
        new RequestProcessingCommand(x => true, new ViewReport<GetTheMainDepartments, IEnumerable<Department>>(
                                                  new GetTheMainDepartments()));
    }

    public class GetTheMainDepartments : IFetchAReport<IEnumerable<Department>>
    {
      public IEnumerable<Department> fetch_report_using(IEncapsulateRequestDetails request)
      {
        return new StubDepartmentRepository().get_the_main_departments();
      }
    }

    public class GetTheDepartmentsInADepartment : IFetchAReport<IEnumerable<Department>>
    {
      public IEnumerable<Department> fetch_report_using(IEncapsulateRequestDetails request)
      {
        throw new NotImplementedException();
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}