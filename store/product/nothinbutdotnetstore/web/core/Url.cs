using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class Url
    {
        public static Predicate<Request> contains(string uri)
        {
            Predicate<Request> predicate = request => request.url.Contains(uri);
            return predicate;
        }
    }
}
