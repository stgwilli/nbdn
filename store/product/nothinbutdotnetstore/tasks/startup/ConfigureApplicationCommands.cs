using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationCommands : ApplicationStartupItem
    {
        public void run()
        {
            register<ViewMainDepartments>(() => new ViewMainDepartments(resolve<CatalogBrowsingTasks>(), resolve<ResponseEngine>()));
            register<ViewSubDepartments>(() => new ViewSubDepartments(resolve<ResponseEngine>(), resolve<CatalogBrowsingTasks>()));
            register<ViewProductsInDepartment>(() => new ViewProductsInDepartment(resolve<ResponseEngine>(), resolve<CatalogBrowsingTasks>()));
            register<AddProductToCart>(() => new AddProductToCart(resolve<ShoppingTasks>()));
        }

        Dependency resolve<Dependency>()
        {
            return IOC.resolve.instance_of<Dependency>();
        }

        void register<Dependency>(Func<object> factory)
        {
            container.Add(typeof (Dependency), new FunctionalContainerItemFactory(factory));
        }

        void register<Dependency>(Dependency item)
        {
            container.Add(typeof (Dependency), new FunctionalContainerItemFactory(() => item));
        }
    }
}

}