using System;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        InputModel map<InputModel>();
        RequestInfo request_info { get; }
    }
}