using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateDisplayHandlers handler_factory;
      private HttpContext current_context;

    public WebFormDisplayEngine(ICreateDisplayHandlers handlers_factory, HttpContext currentContext)
    {
        this.handler_factory = handlers_factory;
        current_context = currentContext;
    }

      public void display<ReportModel>(ReportModel report)
    {
      var handler = handler_factory.create_handler_to_display(report);
          handler.ProcessRequest(current_context);
    }
  }
}