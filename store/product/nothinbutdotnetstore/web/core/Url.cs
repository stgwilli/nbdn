using System;

namespace nothinbutdotnetstore.web.core
{
    public class Url
    {
        static public Predicate<Request> contains(string uri)
        {
            return request => request.url.Contains(uri);
        }
    }
}