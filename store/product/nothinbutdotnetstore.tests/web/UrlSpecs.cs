 
using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class UrlSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {

        }

        [Concern(typeof (Url))]
        public class when_url_contains_command_name : concern
        {
            context c = () =>
            {
                request = an<Request>();
                request_uri = "http://localhost/RawrCommand";
                request.Stub(request1 => request1.url).Return(request_uri);
            };

            because b = () =>
            {
                predicate = Url.contains(request_uri);
            };

            it should_return_a_predicate_that_evaluates_to_true = () =>
            {
                predicate(request).should_be_true();
            };

            static string request_uri;
            static Predicate<Request> predicate;
            static Request request;
        }

        [Concern(typeof(Url))]
        public class when_url_does_not_contain_command_name : concern
        {
            context c = () =>
            {
                request = an<Request>();
                request_uri = "http://localhost/RawrCommand";
                request.Stub(request1 => request1.url).Return(request_uri);

            };

            because b = () =>
            {
                predicate = Url.contains("BlahCommand");
            };

            it should_return_a_predicate_that_evaluates_to_true = () =>
            {
                predicate(request).should_be_false();
            };

            static string request_uri;
            static Predicate<Request> predicate;
            static Request request;
        }
    }
}
