namespace app.web.core
{
  public interface IProcessOneRequest : ISupportAUserFeature
  {
    bool can_run(IEncapsulateRequestDetails request);
  }
}