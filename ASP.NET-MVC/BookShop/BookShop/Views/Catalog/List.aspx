<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<BookShop.Models.Book>> " %>

<%@ Import Namespace="BookShop.Controllers" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Search Results</h2>
    <table>
        <% foreach (var m in ViewData.Model) { %>
        <tr>
        <div class="item">
            <td class="title">
            <%= m.Title %>
            </td>
            <td class="author">
            <%= m.Author %>
            </td>
            <td>
            <%= Html.ActionLink("Details", "Detail", new { id = m.Id })%>
            </td>
            <td>
            <% using (Html.BeginForm("Add", "ShoppingCart", new { bookId = m.Id }, FormMethod.Post))
               { %>
            <input type="submit" value="Add" />
            <% } %>
            </td>
        </div>
        </tr>
        <% } %>
    </table>
</asp:Content>
