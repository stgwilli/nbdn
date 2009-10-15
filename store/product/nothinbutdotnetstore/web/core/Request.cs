using System;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        InputModel map<InputModel>();
        string url { get; set; }
    }
}