using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class ContextWrapper
    {
        public Uri url { get; set; }
        
        public ContextWrapper(HttpContext context)
        {
            url = context.Request.Url;
        }
    }
}