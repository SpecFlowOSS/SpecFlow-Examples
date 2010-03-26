<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BookShop.Models.ShoppingCart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>  
   
 <script type="text/javascript">  
   
     function deleteRecord(recordId)  
     {  
         // Perform delete  
         var action = "/ShoppingCart/DeleteItem/" + recordId;  
               
         var request = new Sys.Net.WebRequest();  
         request.set_httpVerb("DELETE");  
         request.set_url(action);  
         request.add_completed(deleteCompleted);  
         request.invoke();  
     }  
   
     function deleteCompleted()  
     {  
         // Reload page  
         window.location.reload();  
     }  
   
 </script>
    <h2>Shopping Cart Content</h2>

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
    <p>
        Items:</p>
    <% foreach (var lineItem in ViewData.Model.LineItems)
       { %>
    <div class="item">
        Title:
        <span id="title"><%= lineItem.Book.Title%></span>
        <br />
        Quantity:
        <span id="quantity"> <%= lineItem.Quantity%> </span>
        <br />
        Price:
        <span id="price"><%= lineItem.Price%></span>
        <br />
        <%= Html.ActionLink("Edit", "Edit", new { id = lineItem.Book.Id })%>
        <a onclick="deleteRecord(<%= lineItem.Book.Id %>)" href="JavaScript:void(0)">Remove</a> 
        <br />
        <hr />
    </div>
    <% } %>
    <form action="/ShoppingCart/Submit" method="post">
    <input type="submit" value="Submit" />
    </form>
</asp:Content>

