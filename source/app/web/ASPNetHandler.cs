using System;
using System.Web;

namespace app.web
{
  public class ASPNetHandler : IHttpHandler

  {
    public bool IsReusable { get; private set; }

    public void ProcessRequest(HttpContext context)
    {
      throw new NotImplementedException();
    }
  }
}