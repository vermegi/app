using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheProductsInADepartment))]
  public class ViewTheProductsInADepartmentSpecs
  {
      public abstract class concern : Observes<ISupportAUserFeature, ViewTheProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
          request = fake.an<IEncapsulateRequestDetails>();
        new_request = new ProductsInADepartmentRequest();
        renderer = depends.on<IDisplayReports>();
        product_repository = depends.on<IFindProducts>();
        products = new List<Product>();

        request.setup(r => r.map<ProductsInADepartmentRequest>()).Return(new_request);
        product_repository.setup(x => x.get_the_products_for(new_request)).Return(products);
      };

      Because b = () =>
        sut.run(request);

      It should_ask_the_renderer_to_show_the_departments = () =>
        renderer.received(x => x.display(products));

      static IFindProducts product_repository;
      static IEncapsulateRequestDetails request;
      static IDisplayReports renderer;
      static IEnumerable<Product> products;
        static ProductsInADepartmentRequest new_request;
    }
  }
}