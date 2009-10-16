using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartup
    {
        static public void run()
        {
            IOC.initialize_with(new DefaultContainer(new DefaultContainerItemFactoryRegistry(initialize_container_dictionary())));
        }

        private static Dictionary<Type, ContainerItemFactory> initialize_container_dictionary()
        {
            var dictionary = new Dictionary<Type, ContainerItemFactory>
                                 {
                                     {
                                         typeof (ViewFactory),
                                         new FunctionalContainerItemFactory<ViewFactory>(() => new DefaultViewFactory())
                                         },
                                     {
                                         typeof (ResponseEngine), new FunctionalContainerItemFactory<ResponseEngine>(
                                         () => new DefaultResponseEngine(IOC.resolve.instance_of<ViewFactory>()))
                                         },
                                     {
                                         typeof (CatalogBrowsingTasks),
                                         new FunctionalContainerItemFactory<CatalogBrowsingTasks>(
                                         () => new StubCatalogBrowsingTasks())
                                         }
                                 };


            
            dictionary.Add(typeof(List<RequestCommand>), new FunctionalContainerItemFactory<List<RequestCommand>>(() => new List<RequestCommand>
                                       {
                                           new DefaultRequestCommand(Url.contains("ViewMainDepartments"), new ViewMainDepartments(IOC.resolve.instance_of<CatalogBrowsingTasks>(), IOC.resolve.instance_of<ResponseEngine>())),
                                           new DefaultRequestCommand(Url.contains("ViewSubDepartments"), new ViewSubDepartments(IOC.resolve.instance_of<ResponseEngine>(), IOC.resolve.instance_of<CatalogBrowsingTasks>())),
                                           new DefaultRequestCommand(Url.contains("ViewProductsInDepartment"), new ViewProductsInDepartment(IOC.resolve.instance_of<ResponseEngine>(), IOC.resolve.instance_of<CatalogBrowsingTasks>()))
                                       }));
            dictionary.Add(typeof(CommandRegistry), new FunctionalContainerItemFactory<CommandRegistry>(() => new DefaultCommandRegistry(IOC.resolve.instance_of<List<RequestCommand>>())));
            dictionary.Add(typeof(FrontController), new FunctionalContainerItemFactory<FrontController>(() => new DefaultFrontController(IOC.resolve.instance_of<CommandRegistry>())));
            dictionary.Add(typeof(RequestFactory), new FunctionalContainerItemFactory<RequestFactory>(() => new StubRequestFactory()));
            return dictionary;
        }
    }
}