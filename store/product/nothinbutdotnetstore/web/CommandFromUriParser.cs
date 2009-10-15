using System;

namespace nothinbutdotnetstore.web
{
    public interface CommandFromUriParser
    {
        string get_command_name(Uri uri);
    }
}