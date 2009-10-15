using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationWebCommand
    {
        ResponseEngine response_engine;
        CatalogBrowsingTasks catalog_browsing_tasks;

        public ViewSubDepartments(ResponseEngine response_engine, CatalogBrowsingTasks catalog_browsing_tasks)
        {
            this.response_engine = response_engine;
            this.catalog_browsing_tasks = catalog_browsing_tasks;
        }

        public void process(Request request)
        {
            response_engine.process(catalog_browsing_tasks.get_all_departments_in(request.map<Department>()));
        }
    }
}