namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
      private ICreateDisplayHandlers page_factory;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:System.Object"/> class.
      /// </summary>
      public WebFormDisplayEngine(ICreateDisplayHandlers pageFactory)
      {
          page_factory = pageFactory;
      }

      public void display<ReportModel>(ReportModel report)
      {
          page_factory.create_handler_to_display(report);
      }
  }
}