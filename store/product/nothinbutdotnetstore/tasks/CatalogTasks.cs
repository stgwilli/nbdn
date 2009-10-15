using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<Department> get_main_departments();
        IEnumerable<Department> get_all_departments_in(Department department);
    }
}