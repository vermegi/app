using System;
using System.Web;

namespace app.web
{
  public class ASPNetHandler : IHttpHandler

  {
      private IProcessRequests processor;
      private ICreateControllerRequests request_creator;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:System.Object"/> class.
      /// </summary>
      public ASPNetHandler(IProcessRequests processor, ICreateControllerRequests request_creator)
      {
          this.processor = processor;
          this.request_creator = request_creator;
      }

      public bool IsReusable { get; private set; }

    public void ProcessRequest(HttpContext context)
    {
      processor.process(request_creator.create_request_from(context));
    }
  }
}