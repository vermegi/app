using System.Web;

namespace app.web.core.aspnet
{
  public class ASPPageFactory : ICreateDisplayHandlers
  {
    IFindPathsToLogicalViews path_registry;
    CreateRawPage_Behaviour raw_factory;

    public ASPPageFactory(IFindPathsToLogicalViews path_registry, CreateRawPage_Behaviour raw_factory)
    {
      this.path_registry = path_registry;
      this.raw_factory = raw_factory;
    }

    public IHttpHandler create_handler_to_display<ReportModel>(ReportModel the_report)
    {
      var path = path_registry.get_the_path_to_logical_view_for<ReportModel>();
      var view = (IDisplayA<ReportModel>) raw_factory(path, typeof(IDisplayA<ReportModel>));
      view.report_model = the_report;
      return view;
    }
  }
}