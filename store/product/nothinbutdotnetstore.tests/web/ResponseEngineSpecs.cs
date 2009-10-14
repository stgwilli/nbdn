using System.Collections.Generic;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                            DefaultResponseEngine> {}

        [Concern(typeof (DefaultResponseEngine))]
        public class when_processing_the_response : concern
        {
            context c = () =>
            {
                model = "items";
                view_registry = the_dependency<ViewRegistry>();
                view = an<ViewForModel<string>>();

                provide_a_basic_sut_constructor_argument<TransferBehaviour>((handler,preserve) => view_that_was_transferred_to = handler);

                view_registry.Stub(registry => registry.get_view_for<string>()).Return(view);
            };

            because b = () =>
            {
                sut.process(model);
            };


            it should_populate_the_view_with_its_view_model = () =>
            {
                view.model.should_be_equal_to(model);
            };

            it should_transfer_processing_to_the_view_that_can_process_the_view_model = () => {
            
                view_that_was_transferred_to.should_be_equal_to(view);
            };

            static ViewRegistry view_registry;
            static ViewForModel<string> view;
            static string model;
            static IHttpHandler view_that_was_transferred_to;
        }
    }
}