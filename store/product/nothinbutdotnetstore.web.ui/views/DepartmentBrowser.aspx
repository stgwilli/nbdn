<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>


<%@ Import Namespace="System.Runtime.Remoting.Contexts"%>
<%@ Import Namespace="nothinbutdotnetstore.dto" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>

            <%--<table>            
        	<%
            	foreach (var department in this.Model)
        	        %>
        	<%        	    
{        	        %>
        	<tr class="ListItem">
               		 <td>                     
                          <%=department.department_name%>
                	</td>
           	 </tr>        
           	 <%        	    
}            %>
           	 --%>
	    </table>            
</asp:Content>
