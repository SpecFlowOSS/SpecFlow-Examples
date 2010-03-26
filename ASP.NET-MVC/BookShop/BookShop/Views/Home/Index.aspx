<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<BookShop.Models.Book>> " %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to the MVC Bookshop!</h2>
    <h3>We have the following books in stock:</h3>
    <table>
        <% foreach (var m in ViewData.Model) { %>
        <tr>
            <td>
            <%= m.Title %>
            </td>
            <td>
            <%= m.Author %>
            </td>
            <td>
            <%= Html.ActionLink("Details", "Detail", "Catalog", new { id = m.Id }, "")%>
            </td>
         </tr>
        <% } %>
    </table>
</asp:Content>
