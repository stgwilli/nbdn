using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class AddProductToCart : ApplicationWebCommand
    {
        private CatalogTasks catalog_tasks;

        public AddProductToCart(CatalogTasks catalogTasks)
        {
            catalog_tasks = catalogTasks;
        }

        public void process(Request request)
        {
            catalog_tasks.add_to_cart(request.map<Product>());
        }
    }
}