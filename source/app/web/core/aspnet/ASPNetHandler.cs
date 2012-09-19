using System.Web;

namespace app.web.core.aspnet
{
  public class ASPNetHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateControllerRequests request_factory;

    public ASPNetHandler(IProcessRequests processRequests, ICreateControllerRequests createControllerRequests)
    {
      this.front_controller = processRequests;
      this.request_factory = createControllerRequests;
    }

    public void ProcessRequest(HttpContext context)
    {
      var request = request_factory.create_request_from(context);
      this.front_controller.process(request);
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}