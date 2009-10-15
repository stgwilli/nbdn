using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
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
                view_factory = the_dependency<ViewFactory>();
                view = an<ViewForModel<string>>();

                provide_a_basic_sut_constructor_argument<TransferBehaviour>((handler,preserve) => view_that_was_transferred_to = handler);

                view_factory.Stub(registry => registry.create_view_for(model)).Return(view);
            };

            because b = () =>
            {
                sut.process(model);
            };


            it should_transfer_processing_to_the_view_that_can_process_the_view_model = () => {
            
                view_that_was_transferred_to.should_be_equal_to(view);
            };

            static ViewFactory view_factory;
            static ViewForModel<string> view;
            static string model;
            static IHttpHandler view_that_was_transferred_to;
        }
    }
}