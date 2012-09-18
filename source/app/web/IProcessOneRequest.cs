namespace app.web
{
  public interface IProcessOneRequest
  {
    void run(IEncapsulateRequestDetails request);
    bool can_run(IEncapsulateRequestDetails request);
  }
}