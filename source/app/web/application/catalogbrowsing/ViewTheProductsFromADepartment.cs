using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheProductsFromADepartment : ISupportAUserFeature
  {
    IFindProducts products_repository;
    IDisplayReports display_engine;

    public ViewTheProductsFromADepartment(IFindProducts products_repository, IDisplayReports display_engine)
    {
      this.products_repository = products_repository;
      this.display_engine = display_engine;
    }

    public ViewTheProductsFromADepartment(): this(new StubProductRepository(), new StubDisplayEngine())
    {
    }

    public void run(IEncapsulateRequestDetails request)
    {
      display_engine.display(products_repository.get_products_from_department(request.map<ProductsFromADepartmentRequest>()));
    }
  }
}