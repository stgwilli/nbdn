<%@ Application Language="C#" %>
<%@ Import Namespace="nothinbutdotnetstore.tasks.startup" %>
<script runat="server">

        void Application_Start(object sender, EventArgs e)
        {
            ApplicationStartup.start();
        }

        
</script>
