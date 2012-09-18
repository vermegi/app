namespace app.web
{
  public class RequestProcessingCommand : IProcessOneRequest
  {
    public void run(IEncapsulateRequestDetails request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_run(IEncapsulateRequestDetails request)
    {
      throw new System.NotImplementedException();
    }
  }
}