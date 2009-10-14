using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
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