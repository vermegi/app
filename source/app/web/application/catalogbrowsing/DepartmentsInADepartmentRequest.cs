using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public class DepartmentsInADepartmentRequest : IEncapsulateRequestDetails
    {
        public string department_name { get; set; }
    }
}