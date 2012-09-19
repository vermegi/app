using System;
using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IEncapsulateRequestDetails create_request_from(HttpContext an_context)
    {
      return new StubRequest();
    }

    class StubRequest : IEncapsulateRequestDetails
    {
      public InputModel map<InputModel>()
      {
        return Activator.CreateInstance<InputModel>();
      }
    }
  }
}