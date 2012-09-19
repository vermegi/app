using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : ISupportAUserFeature
    {
        private IFindProducts product_repository;
        private IDisplayReports displayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ViewTheProductsInADepartment() : this(new StubProductRepository(), new StubDisplayEngine())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ViewTheProductsInADepartment(IFindProducts productRepository, IDisplayReports displayer)
        {
            product_repository = productRepository;
            this.displayer = displayer;
        }

        public void run(IEncapsulateRequestDetails request)
        {
            displayer.display(product_repository.get_the_products_for(request.map<ProductsInADepartmentRequest>()));
        }
    }
}