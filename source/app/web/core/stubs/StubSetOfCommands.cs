using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new RequestProcessingCommand(x => true, new ViewTheProductsInADepartment());
//      yield return new RequestProcessingCommand(x => true, new ViewTheMainDepartmentsInTheStore());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}