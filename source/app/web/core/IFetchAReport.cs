namespace app.web.core
{
  public interface IFetchAReport<out ReportModel>
  {
    ReportModel fetch_report_using(IEncapsulateRequestDetails request);
  }
}