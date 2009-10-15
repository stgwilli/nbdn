using System;
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
                                            ViewCommand<IEnumerable<Product>>> {}

        [Concern(typeof (ViewProductsInDepartment))]
        public class when_viewing_a_list_of_products_in_a_department : concern
        {
            context c = () =>
            {
                request = an<Request>();
                products = new List<Product>();
                catalog_browsing = the_dependency<CatalogBrowsingTasks>();
                response_engine = the_dependency<ResponseEngine>();

                department = new Department();

                catalog_browsing.Stub(tasks => tasks.get_products_in(department)).Return(products);
                request.Stub(request1 => request1.map<Department>()).Return(department);

                provide_a_basic_sut_constructor_argument<ViewQuery<IEnumerable<Product>>>(x => catalog_browsing.get_products_in(request.map<Department>()));
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
            static CatalogBrowsingTasks catalog_browsing;
            static ResponseEngine response_engine;
            static Department department;
        }
    }
}