using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindProducts
  {
    IEnumerable<Product> get_products_from_department(ProductsFromADepartmentRequest request);
  }
}