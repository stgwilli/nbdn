 using System;
 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RequestFactory,
                                            StubRequestFactory>
        {
        
        }

        [Concern(typeof(StubRequestFactory))]
        public class when_creating_a_request : concern
        {
            context c = () =>
                            {
                                uri = new Uri("http://blah.com");
                                request = an<Request>();
                            };

            because b = () =>
                            {
                                request = sut.create_from(uri);
                            };

            it should_add_the_uri_to_the_request = () =>
                                                       {
                                                           uri.should_be_equal_to(request.uri);
                                                       };

            private static Uri uri;
            private static Request request;
        }
    }
}