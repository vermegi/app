using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewReport<,>))]
  public class ViewReportSpecs
  {
    public abstract class concern :
      Observes<ISupportAUserFeature, ViewReport<SomeQuery, SomeItem>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        renderer = depends.on<IDisplayReports>();
        item = new SomeItem();
        depends.on(new SomeQuery(item));
      };

      Because b = () =>
        sut.run(request);

      It should_ask_the_renderer_to_show_the_report_fetched_by_the_query_object = () =>
        renderer.received(x => x.display(item));

      static IEncapsulateRequestDetails request;
      static IDisplayReports renderer;
      static SomeItem item;
    }

    public class SomeItem
    {
    }

    public class SomeQuery : IFetchAReport<SomeItem>
    {
      SomeItem result;

      public SomeQuery(SomeItem result)
      {
        this.result = result;
      }

      public SomeItem fetch_report_using(IEncapsulateRequestDetails request)
      {
        return result;
      }
    }
  }
}