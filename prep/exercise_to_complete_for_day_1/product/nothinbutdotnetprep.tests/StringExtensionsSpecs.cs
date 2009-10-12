using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.tests
{
    public class StringExtensionsSpecs
    {
        [Concern(typeof (StringExtensions))]
        public class when_the_string_extensions_formats_a_string_using_provided_arguments : observations_for_a_static_sut
        {
            static string result;

            because b = () =>
            {
                result = "this is the {0}".format_using(1);
            };


            it should_return_the_string_formatted_with_the_arguments = () =>
            {
                result.should_be_equal_to("this is the 1");
            };
        }
    }
}