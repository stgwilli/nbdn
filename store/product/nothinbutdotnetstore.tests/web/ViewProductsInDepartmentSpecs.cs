using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewProductsInDepartmentSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewProductsInDepartment> {}

        [Concern(typeof (ViewProductsInDepartment))]
        public class when_viewing_a_list_of_products_in_a_department : concern
        {
            context c = () =>
            {
                request = an<Request>();
                products = new List<Product>();
                catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                response_engine = the_dependency<ResponseEngine>();

                department = new Department();

                catalog_browsing_tasks.Stub(tasks => tasks.get_products_in(department)).Return(products);

                request.Stub(request1 => request1.map<Department>()).Return(department);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_a_list_of_products_for_the_department = () =>
            {
                response_engine.received(engine => engine.process(products));
            };

            static Request request;
            static IEnumerable<Product> products;
            static CatalogBrowsingTasks catalog_browsing_tasks;
            static ResponseEngine response_engine;
            static Department department;
        }
    }
}