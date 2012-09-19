namespace app.web.core
{
  public interface IFind
  {
    ReportModel find<SpecificRequest, ReportModel>(SpecificRequest request);
  }
}