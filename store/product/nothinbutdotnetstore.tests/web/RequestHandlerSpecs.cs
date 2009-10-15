 using System;
 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tests.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestHandlerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<IHttpHandler,
                                             RequestHandler>
         {
        
         }

         [Concern(typeof(RequestHandler))]
         public class when_processing_an_incoming_http_context : concern
         {
             context c = () =>
             {
                 http_context = ObjectMother.create_http_context();
                 request = an<Request>();
                 front_controller = the_dependency<FrontController>();
                 request_factory = the_dependency<RequestFactory>();
                 
                 request_factory.Stub(factory => factory.create_from(Arg<Uri>.Is.Anything)).Return(request);
             };

             because b = () =>
             {
                 sut.ProcessRequest(http_context);
             };

        
             it should_dispatch_a_request_to_the_front_controller_infrastructure = () =>
             {
                 front_controller.received(controller1 => controller1.process(request));
             };

             static HttpContext http_context;
             static FrontController front_controller;
             static RequestFactory request_factory;
             static Request request;
             private static Uri uri;
         }
     }
 }
