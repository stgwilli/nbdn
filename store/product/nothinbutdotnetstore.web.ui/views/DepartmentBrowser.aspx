<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.dto"%>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>

            <table>            
		<!-- for each of the main departments in the store -->
        	<% 
        	foreach (var dept in (IEnumerable)HttpContext.Current.Items["ViewModel"]) 
            %>
        	<%{%>
        	<tr class="ListItem">
               		 <td>                     
                          <%= ((Department)dept).department_name %>
                	</td>
           	 </tr>        
           	 <%}%>
           	 
	    </table>            
</asp:Content>
