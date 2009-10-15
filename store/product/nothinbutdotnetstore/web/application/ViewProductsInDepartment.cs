using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInDepartment : ApplicationWebCommand
    {
        private ResponseEngine response_engine;
        private CatalogBrowsingTasks catalog_browsing_tasks;

        public ViewProductsInDepartment(ResponseEngine responseEngine, CatalogBrowsingTasks catalog_browsing_tasks)
        {
            response_engine = responseEngine;
            this.catalog_browsing_tasks = catalog_browsing_tasks;
        }

        public void process(Request request)
        {
            response_engine.process(catalog_browsing_tasks.get_products_in(request.map<Department>()));
        }
    }
}