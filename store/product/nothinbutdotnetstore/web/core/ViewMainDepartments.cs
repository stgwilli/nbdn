using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationWebCommand
    {
        CatalogTasks catalog;
        View<IEnumerable<Department>> view;

        public ViewMainDepartments(CatalogTasks catalog, View<IEnumerable<Department>> view)
        {
            this.catalog = catalog;
            this.view = view;
        }

        public void process(Request request)
        {
            view.display(catalog.get_main_departments());
        }
    }
}