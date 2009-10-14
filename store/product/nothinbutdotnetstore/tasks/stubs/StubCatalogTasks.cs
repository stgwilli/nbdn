using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<Department> get_main_departments()
        {
            return Enumerable.Range(1, 100).Select(i => new Department());
        }
    }
}