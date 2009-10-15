using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInDepartment : ApplicationWebCommand
    {
        private ResponseEngine response_engine;
        private CatalogTasks catalog_tasks;

        public ViewProductsInDepartment(ResponseEngine responseEngine, CatalogTasks catalogTasks)
        {
            response_engine = responseEngine;
            catalog_tasks = catalogTasks;
        }

        public void process(Request request)
        {
            response_engine.process(catalog_tasks.get_products_in(request.map<Department>()));
        }
    }
}