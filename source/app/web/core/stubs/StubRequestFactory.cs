using System.Web;
using app.web.application.catalogbrowsing;

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
        object item = new ProductsInADepartmentRequest();
        return (InputModel) item;
      }
    }
  }
}