using System.Web;

namespace nothinbutdotnetstore.web.application
{
    public class DefaultPayload : Payload
    {

        private readonly string ViewModel = "view_model";

        public void store<T>(T view_model)
        {
            HttpContext.Current.Items.Add(ViewModel, view_model);
        }

        public T retrieve<T>()
        {
            return (T) HttpContext.Current.Items[ViewModel];
        }
    }
}