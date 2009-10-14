 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ViewMainDepartmentsSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                             ViewMainDepartments>
         {
        
         }

         [Concern(typeof(ViewMainDepartments))]
         public class when_viewing_main_departments : concern
         {
             context c = () =>
                             {
                                 departments = an<IEnumerable<Department>>();
                                 request = an<Request>();
                                 store = the_dependency<DepartmentStore>();
                                 view = the_dependency<View<IEnumerable<Department>>>();

                                 store.Stub(x => x.get_main_departments()).Return(departments);
                             };

             because b = () =>
                             {
                                    sut.process(request);
                             };

        
             it view_should_display_a_list_of_departments = () =>
                        {
                            view.received(x => x.display(departments));
                        };

             private static Request request;
             private static DepartmentStore store;
             private static View<IEnumerable<Department>> view;
             private static IEnumerable<Department> departments;
         }


         



     }
 }
