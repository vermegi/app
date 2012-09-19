using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheProductsFromADepartment))]
    public class ViewTheProductsFromADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature, ViewTheProductsFromADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        product_name = "my super, duper cool product";
        request = fake.an<IEncapsulateRequestDetails>();
        new_request = new ProductsFromADepartmentRequest();
        renderer = depends.on<IDisplayReports>();
        product_repository = depends.on<IFindProducts>();
        products = new List<Product>();

        request.setup(r => r.map<ProductsFromADepartmentRequest>()).Return(new_request);
        product_repository.setup(x => x.get_products_from_department(new_request)).Return(products);
      };

      Because b = () =>
        sut.run(request);

      It should_ask_the_renderer_to_show_the_products = () =>
        renderer.received(x => x.display(products));

      static IFindProducts product_repository;
      static IEncapsulateRequestDetails request;
      static IDisplayReports renderer;
      static IEnumerable<Product> products;
      static string product_name;
      static ProductsFromADepartmentRequest new_request;
    }
  }
}