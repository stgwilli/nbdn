using System;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewRegistry : ViewRegistry
    {
        public ViewForModel<ViewModel> get_view_for<ViewModel>()
        {
            throw new NotImplementedException();
        }
    }
}