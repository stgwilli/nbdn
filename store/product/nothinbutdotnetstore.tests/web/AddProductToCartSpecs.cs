using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class AddProductToCartSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            AddProductToCart> {}

        [Concern(typeof (AddProductToCart))]
        public class when_adding_a_product_to_cart : concern
        {
            context c = () =>
            {
                request = an<Request>();
                shopping_tasks = the_dependency<ShoppingTasks>();
                product = new Product();


                request.Stub(x => x.map<Product>()).Return(product);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_be_told_to_add_a_product_to_the_cart = () =>
            {
                shopping_tasks.received(x => x.add_to_cart(product));
            };

            static Request request;
            static ShoppingTasks shopping_tasks;
            static Product product;
        }
    }
}