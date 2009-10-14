using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationWebCommand
    {
        private readonly DepartmentStore store;
        private readonly View<IEnumerable<Department>> view;

        public ViewMainDepartments(DepartmentStore store, View<IEnumerable<Department>> view)
        {
            this.store = store;
            this.view = view;
        }

        public void process(Request request)
        {
            view.display(store.get_main_departments());
        }
    }
}