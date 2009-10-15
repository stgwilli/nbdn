using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationWebCommand
    {
        CatalogBrowsingTasks catalog_browsing;
        ResponseEngine response_engine;

        public ViewMainDepartments(CatalogBrowsingTasks catalog_browsing, ResponseEngine response_engine)
        {
            this.catalog_browsing = catalog_browsing;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.process(catalog_browsing.get_main_departments());
        }
    }
}