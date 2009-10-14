using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewMainDepartments> {}

        [Concern(typeof (ViewMainDepartments))]
        public class when_viewing_main_departments : concern
        {
            context c = () =>
            {
                departments = an<IEnumerable<Department>>();
                request = an<Request>();
                catalog = the_dependency<CatalogTasks>();
                view = the_dependency<View<IEnumerable<Department>>>();

                catalog.Stub(x => x.get_main_departments()).Return(departments);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it view_should_display_a_list_of_departments = () =>
            {
                view.received(x => x.display(departments));
            };

            static Request request;
            static CatalogTasks catalog;
            static View<IEnumerable<Department>> view;
            static IEnumerable<Department> departments;
        }
    }
}