using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
    public class StubProductRepository : IFindProducts
    {
        public IEnumerable<Product> get_the_products_for(ProductsInADepartmentRequest newRequest)
        {
            return Enumerable.Range(1, 100).Select(x => new Product { name = x.ToString("product 0")});
        }
    }
}