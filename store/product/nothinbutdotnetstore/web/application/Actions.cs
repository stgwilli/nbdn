using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class Actions
    {
        public static ViewCommand<IEnumerable<Department>> ViewMainDepartments =
            new ViewCommand<IEnumerable<Department>>(x => new StubCatalogBrowsingTasks().get_main_departments());

        public static ViewCommand<IEnumerable<Department>> ViewSubDepartments =
            new ViewCommand<IEnumerable<Department>>(
                x => new StubCatalogBrowsingTasks().get_all_departments_in(x.map<Department>()));

        public static ViewCommand<IEnumerable<Product>> ViewProductsInDerpartments =
            new ViewCommand<IEnumerable<Product>>(
                x => new StubCatalogBrowsingTasks().get_products_in(x.map<Department>()));
    }
}