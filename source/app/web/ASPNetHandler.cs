using System;
using System.Web;

namespace app.web
{
  public class ASPNetHandler : IHttpHandler
  {
      private IProcessRequests _frontController;
      private ICreateControllerRequests _requestFactory;

      public ASPNetHandler(IProcessRequests processRequests, ICreateControllerRequests createControllerRequests)
      {
          this._frontController = processRequests;
          this._requestFactory = createControllerRequests;
      }

    public bool IsReusable { get; private set; }

    public void ProcessRequest(HttpContext context)
    {
        var request = _requestFactory.create_request_from(context);
        this._frontController.process(request);
    }
  }
}