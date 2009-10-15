using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class AddProductToCart : ApplicationWebCommand
    {
        private ShoppingTasks shopping_tasks;

        public AddProductToCart(ShoppingTasks shopping_tasks)
        {
            this.shopping_tasks = shopping_tasks;
        }

        public void process(Request request)
        {
            shopping_tasks.add_to_cart(request.map<Product>());
        }
    }
}