namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
      private ICreateDisplayHandlers displayHandlersFactory;

      public WebFormDisplayEngine(ICreateDisplayHandlers displayHandlersFactory)
      {
          this.displayHandlersFactory = displayHandlersFactory;
      }

      public void display<ReportModel>(ReportModel report)
    {
      displayHandlersFactory.create_handler_to_display(report);
    }
  }
}