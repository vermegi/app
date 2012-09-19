namespace app.web.core.aspnet
{
  public interface IFindPathsToLogicalViews
  {
    string get_the_path_to_logical_view_for<ReportModel>();
  }
}