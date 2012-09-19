using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateDisplayHandlers
  {
    IHttpHandler create_handler_to_display<ReportModel>(ReportModel the_report);
  }
}