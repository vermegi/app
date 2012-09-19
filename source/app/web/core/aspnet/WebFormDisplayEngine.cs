using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateDisplayHandlers handler_factory;
    GetTheCurrentlyExecutingRequest_Behaviour current_request_resolution;

    public WebFormDisplayEngine():this(new ASPPageFactory(),() => HttpContext.Current)
    {
    }

    public WebFormDisplayEngine(ICreateDisplayHandlers handlers_factory,
                                GetTheCurrentlyExecutingRequest_Behaviour current_request_resolution)
    {
      this.handler_factory = handlers_factory;
      this.current_request_resolution = current_request_resolution;
    }

    public void display<ReportModel>(ReportModel report)
    {
      var handler = handler_factory.create_handler_to_display(report);
      handler.ProcessRequest(current_request_resolution());
    }
  }
}