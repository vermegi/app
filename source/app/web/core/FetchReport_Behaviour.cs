namespace app.web.core
{
  public delegate ReportModel FetchReport_Behaviour<out ReportModel>(IEncapsulateRequestDetails request);
}