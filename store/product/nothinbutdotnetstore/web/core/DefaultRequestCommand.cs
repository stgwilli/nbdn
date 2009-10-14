using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        Predicate<Request> request_criteria;
        ApplicationWebCommand application_command;

        public DefaultRequestCommand(Predicate<Request> request_criteria,ApplicationWebCommand command)
        {
            this.request_criteria = request_criteria;
            this.application_command = command;
        }

        public void process(Request request)
        {
            application_command.process(request);
        }

        public bool can_handle(Request request)
        {
            return request_criteria(request);
        }
    }
}