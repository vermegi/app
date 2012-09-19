using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry : IFindPathsToLogicalViews
  {
    public string get_the_path_to_logical_view_for<ReportModel>()
    {
      var paths = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<Department>), create_path_to("DepartmentBrowser")},
        {typeof(IEnumerable<Product>), create_path_to("ProductBrowser")},
      };
      return paths[typeof(ReportModel)];
    }

    string create_path_to(string page_name)
    {
      return string.Format("~/views/{0}.aspx", page_name);
    }
  }
}