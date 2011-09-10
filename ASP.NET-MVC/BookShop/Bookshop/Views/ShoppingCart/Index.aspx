<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage<BookShop.Models.ShoppingCart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Shopping Cart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="http://ajax.microsoft.com/ajax/beta/0909/MicrosoftAjax.js" type="text/javascript"></script>

    <script type="text/javascript">

        function deleteRecord(recordId) {
            // Perform delete  
            var action = "/ShoppingCart/DeleteItem/" + recordId;

            var request = new Sys.Net.WebRequest();
            request.set_httpVerb("DELETE");
            request.set_url(action);
            request.add_completed(deleteCompleted);
            request.invoke();
        }

        function deleteCompleted() {
            // Reload page  
            window.location.reload();
        }  
   
    </script>

    <fieldset>
        <legend>Overview</legend>
        <p>
            Total Price:
            <%= Html.Encode(String.Format("{0:F}", Model.Price)) %>
        </p>
        <p>
            Total Items:
            <%= Html.Encode(Model.Count) %>
        </p>
    </fieldset>
    <% foreach (var lineItem in ViewData.Model.Lines)
       { 
           Html.RenderPartial("OrderLine", lineItem); 
       } %>
    <% using (Html.BeginForm("Submit", "ShoppingCart"))
       {%>
    <input type="submit" value="Submit Order" />
    <% } %>
</asp:Content>
