using System.Web.UI;

namespace app.web.core.aspnet
{
  public class LogicalViewForA<ReportModel> :Page,IDisplayA<ReportModel>
  {
    public ReportModel report_model { get; set; }
  }
}