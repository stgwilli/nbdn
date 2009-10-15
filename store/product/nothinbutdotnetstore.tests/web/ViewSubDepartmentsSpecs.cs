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
    public class ViewSubDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewSubDepartments> {}

        [Concern(typeof (ViewSubDepartments))]
        public class when_viewing_the_list_of_departments_in_a_department : concern
        {
            context c = () =>
            {
                request = an<Request>();
                sub_departments = new List<Department>();
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();

                main_department = new Department();

                catalog_tasks.Stub(tasks => tasks.get_all_departments_in(main_department)).Return(sub_departments);

                request.Stub(request1 => request1.map<Department>()).Return(main_department);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_only_the_departments_in_that_department = () =>
            {
                response_engine.received(engine => engine.process(sub_departments));
            };

            static ResponseEngine response_engine;
            static IEnumerable<Department> sub_departments;
            static Request request;
            static Department main_department;
            static CatalogTasks catalog_tasks;
        }
    }
}