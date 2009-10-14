using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface DepartmentStore
    {
        IEnumerable<Department> get_main_departments();
    }
}