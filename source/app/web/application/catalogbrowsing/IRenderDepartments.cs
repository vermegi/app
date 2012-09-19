using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IRenderDepartments
    {
        void display(IEnumerable<Department> departments);
    }
}