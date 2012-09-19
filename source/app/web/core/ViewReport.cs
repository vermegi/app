using app.web.core.aspnet;

namespace app.web.core
{
  public class ViewReport<QueryObject, ReportModel> : ISupportAUserFeature
    where QueryObject : IFetchAReport<ReportModel>
  {
    QueryObject query;
    IDisplayReports report_engine;

    public ViewReport(QueryObject query, IDisplayReports report_engine)
    {
      this.query = query;
      this.report_engine = report_engine;
    }

    public ViewReport(QueryObject query) : this(query, new WebFormDisplayEngine())
    {
    }

    public void run(IEncapsulateRequestDetails request)
    {
      report_engine.display(query.fetch_report_using(request));
    }
  }
}