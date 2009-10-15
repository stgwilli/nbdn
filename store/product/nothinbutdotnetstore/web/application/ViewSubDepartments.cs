using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationWebCommand
    {
        ResponseEngine response_engine;
        CatalogTasks catalog_tasks;

        public ViewSubDepartments(ResponseEngine response_engine, CatalogTasks catalog_tasks)
        {
            this.response_engine = response_engine;
            this.catalog_tasks = catalog_tasks;
        }

        public void process(Request request)
        {
            response_engine.process(catalog_tasks.get_all_departments_in(request.map<Department>()));
        }
    }
}