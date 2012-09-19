using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubProductRepository : IFindProducts
  {
      public IEnumerable<Product> get_products_from_department(ProductsFromADepartmentRequest request)
      {
          return Enumerable.Range(1, 100).Select(x => new Product() { name = x.ToString("Product 0"), price = 342 });
      }
  }
}