namespace app.web.core
{
  public class RequestProcessingCommand : IProcessOneRequest
  {
    RequestMatch_Behaviour request_specification;
    ISupportAUserFeature feature;

    public RequestProcessingCommand(RequestMatch_Behaviour request_specification, ISupportAUserFeature feature)
    {
      this.request_specification = request_specification;
      this.feature = feature;
    }

    public void run(IEncapsulateRequestDetails request)
    {
      feature.run(request);
    }

    public bool can_run(IEncapsulateRequestDetails request)
    {
      return request_specification(request);
    }
  }
}