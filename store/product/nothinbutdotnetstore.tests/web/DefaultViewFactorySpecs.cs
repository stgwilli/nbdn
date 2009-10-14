using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class DefaultViewFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ViewFactory,
                                            DefaultViewFactory> {}

        [Concern(typeof (DefaultViewFactory))]
        public class when_creating_a_view_for_a_view_model : concern
        {
            context c = () =>
            {
                model = "blah";
                view = an<ViewForModel<string>>();
                view_registry = the_dependency<ViewRegistry>();
                physical_view_path = "path";
                view_registry.Stub(registry => registry.get_view_path_for<string>()).Return(physical_view_path);

                provide_a_basic_sut_constructor_argument<PageFactory>((path, type) =>
                {
                    page_type = type;
                    view_path = path;
                    return view;
                });
            };

            because b = () =>
            {
                result = sut.create_view_for(model);
            };

            it should_use_the_page_type_to_create_the_page_instance = () =>
            {
                page_type.should_be_equal_to(typeof (ViewForModel<string>)); 

            };

            it should_create_the_view_and_set_its_model_property = () =>
            {
                view_path.should_be_equal_to(physical_view_path);
                result.should_be_equal_to(view);
                result.model.should_be_equal_to(model);
            };

            static ViewForModel<string> result;
            static ViewForModel<string> view;
            static string model;
            static string view_path;
            static ViewRegistry view_registry;
            static string physical_view_path;
            static Type page_type;
        }
    }
}