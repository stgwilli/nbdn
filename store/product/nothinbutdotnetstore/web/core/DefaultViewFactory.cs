using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewFactory : ViewFactory
    {
        ViewRegistry view_registry;
        PageFactory page_factory;

        public DefaultViewFactory() : this(new StubViewRegistry(), (path,type) => BuildManager.CreateInstanceFromVirtualPath(path, type))
        {
        }

        public DefaultViewFactory(ViewRegistry view_registry, PageFactory page_factory)
        {
            this.view_registry = view_registry;
            this.page_factory = page_factory;
        }

        public ViewForModel<ViewModel> create_view_for<ViewModel>(ViewModel model)
        {
            var path = view_registry.get_view_path_for<ViewModel>();
            var page = (ViewForModel<ViewModel>) page_factory(path, typeof (ViewForModel<ViewModel>));
            page.model = model;
            return page;
        }
    }
}