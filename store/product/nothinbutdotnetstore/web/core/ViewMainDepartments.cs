using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationWebCommand
    {
        CatalogTasks catalog;
        ResponseEngine response_engine;

        public ViewMainDepartments(CatalogTasks catalog, ResponseEngine response_engine)
        {
            this.catalog = catalog;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.process(catalog.get_main_departments());
        }
    }
}