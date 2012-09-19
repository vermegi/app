using System.Web;

namespace app.web.core
{
  public interface ICreateControllerRequests
  {
    IEncapsulateRequestDetails create_request_from(HttpContext an_context);
  }
}