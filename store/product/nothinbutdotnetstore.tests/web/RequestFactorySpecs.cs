 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<RequestFactory,
                                             DefaultRequestFactory>
         {
        
         }

         [Concern(typeof(DefaultRequestFactory))]
         public class when_creating_a_request_from_an_http_context : concern
         {
             context c = () =>
                             {

                             };

             because b = () =>
                             {

                             };

             it should_return_the_request_with_the_correct_information = () =>
                        {
                            
            
            
                        };

         }
     }
 }
