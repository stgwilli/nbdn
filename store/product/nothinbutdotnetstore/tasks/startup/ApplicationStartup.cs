using System;
using System.Collections.Generic;
using System.Web.Compilation;
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
        IDictionary<Type, ContainerItemFactory> container;

        static public void start()
        {
            new ApplicationStartup(new Dictionary<Type, ContainerItemFactory>());
        }

        public ApplicationStartup(IDictionary<Type, ContainerItemFactory> container)
        {
            this.container = container;
            run();
        }

        public void run()
        {
//            Start.by<ConfiguringCoreServices>()
//                .followed_by<ConfiguringFrontController>()
//                .followed_by<ConfigureRouting>();

            
            configure_core_services();
            configure_service_layer();
            configure_front_controller();
            configure_routing();    
            configure_application_commands();
        }

        void configure_core_services()
        {
            IOC.initialize_with(new DefaultContainer(new DefaultContainerItemFactoryRegistry(container)));
        }

        void configure_application_commands()
        {
            register<ViewMainDepartments>(() => new ViewMainDepartments(resolve<CatalogBrowsingTasks>(), resolve<ResponseEngine>()));
            register<ViewSubDepartments>(() => new ViewSubDepartments(resolve<ResponseEngine>(), resolve<CatalogBrowsingTasks>()));
            register<ViewProductsInDepartment>(() => new ViewProductsInDepartment(resolve<ResponseEngine>(), resolve<CatalogBrowsingTasks>()));
            register<AddProductToCart>(() => new AddProductToCart(resolve<ShoppingTasks>()));
        }

        void configure_service_layer()
        {
            register<CatalogBrowsingTasks>(() => new StubCatalogBrowsingTasks());
        }

        void configure_front_controller()
        {
            register<PageFactory>((path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type));
            register<FrontController>(() => new DefaultFrontController(resolve<CommandRegistry>()));
            register<CommandRegistry>(() => new DefaultCommandRegistry(resolve<IEnumerable<RequestCommand>>()));
            register<RequestFactory>(() => new StubRequestFactory());
            register<ResponseEngine>(() => new DefaultResponseEngine(resolve<ViewFactory>()));
            register<ViewRegistry>(() => new StubViewRegistry());
            register<ViewFactory>(() => new DefaultViewFactory(resolve<ViewRegistry>(), resolve<PageFactory>()));
        }

        void configure_routing()
        {
            register<IEnumerable<RequestCommand>>(() => create_routes());
        }

        IEnumerable<RequestCommand> create_routes()
        {
            yield return create_command<ViewMainDepartments>();
            yield return create_command<ViewProductsInDepartment>();
            yield return create_command<ViewSubDepartments>();
            yield return create_command<AddProductToCart>();
        }

        RequestCommand create_command<AppCommand>() where AppCommand : ApplicationWebCommand
        {
            return new DefaultRequestCommand(Url.contains(typeof (AppCommand).Name), resolve<AppCommand>());
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
    } ;
}