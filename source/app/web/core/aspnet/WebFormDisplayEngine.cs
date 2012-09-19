namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateDisplayHandlers handler_factory;

    public WebFormDisplayEngine(ICreateDisplayHandlers handlers_factory)
    {
      this.handler_factory = handlers_factory;
    }

    public void display<ReportModel>(ReportModel report)
    {
      handler_factory.create_handler_to_display(report);
    }
  }
}