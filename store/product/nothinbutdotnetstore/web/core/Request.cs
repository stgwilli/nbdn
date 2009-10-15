using System;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        InputModel map<InputModel>();
        Uri uri { get; set; }
    }
}