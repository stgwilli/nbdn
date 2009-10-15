using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface ShoppingTasks
    {
        void add_to_cart(Product product);
    }

    public interface CatalogBrowsingTasks
    {
        IEnumerable<Department> get_main_departments();
        IEnumerable<Department> get_all_departments_in(Department department);
        IEnumerable<Product> get_products_in(Department department);
    }
}