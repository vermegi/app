﻿using System.Collections;
using System.Collections.Generic;
using app.utility.container;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
        yield return new RequestProcessingCommand(x => x.somedata.Contains("products"), new ViewReport<GetTheProducts, IEnumerable<Product>>(
                                                  new GetTheProducts(), Dependencies.fetch.an<IDisplayReports>()));
        yield return
          new RequestProcessingCommand(x => x.somedata.Contains("departments"), new ViewReport<GetTheDepartmentsInADepartment, IEnumerable<Department>>(
                                                    new GetTheDepartmentsInADepartment(), Dependencies.fetch.an<IDisplayReports>()));

        yield return
          new RequestProcessingCommand(x => x.somedata.Contains("departmentsinadepartment"), new ViewReport<GetTheMainDepartments, IEnumerable<Department>>(
                                                    new GetTheMainDepartments(), Dependencies.fetch.an<IDisplayReports>()));
    } 

    public class GetTheMainDepartments : IFetchAReport<IEnumerable<Department>>
    {
      public IEnumerable<Department> fetch_report_using(IEncapsulateRequestDetails request)
      {
        return new StubDepartmentRepository().get_the_main_departments();
      }
    }

    public class GetTheDepartmentsInADepartment : IFetchAReport<IEnumerable<Department>>
    {
      public IEnumerable<Department> fetch_report_using(IEncapsulateRequestDetails request)
      {
        return new StubDepartmentRepository().get_the_departments_for(request.map<DepartmentsInADepartmentRequest>());
      }
    }

    public class GetTheProducts : IFetchAReport<IEnumerable<Product>>
    {
      public IEnumerable<Product> fetch_report_using(IEncapsulateRequestDetails request)
      {
        return new StubProductRepository().get_products_from_department(request.map<ProductsFromADepartmentRequest>());
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}