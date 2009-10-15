 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ActionFromUriParserSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<CommandFromUriParser,
                                             DefaultCommandFromUriParser>
         {
        
         }

         [Concern(typeof(DefaultCommandFromUriParser))]
         public class when_parsing_a_uri : concern
         {
             context c = () =>
                             {
                                 uri = new Uri("blahcommand");
                             };

             because b = () =>
                             {
                                 command_name = sut.get_command_name(uri);
                             };

        
             it should_return_a_command_name_from_the_uri_using_the_request_uri = () =>
                        {
                            command_name.should_be_equal_to("blahcommand");
                        };

             private static string command_name;
             private static Uri uri;
         }
     }

     public class DefaultCommandFromUriParser: CommandFromUriParser
     {
         public string get_command_name(Uri uri)
         {
             throw new NotImplementedException();
         }
     }
 }
