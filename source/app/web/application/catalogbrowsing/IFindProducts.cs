using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindProducts
    {
        IEnumerable<Product> get_the_products_for(ProductsInADepartmentRequest newRequest);
    }
}