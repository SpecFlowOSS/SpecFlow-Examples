<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Bookshop.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List Books
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <% foreach (var m in ViewData.Model)
           { %>
        <tr>
            <div class="item">
                <td class="title">
                    <%= m.Title %>
                </td>
                <td class="author">
                    <%= m.Author %>
                </td>
                <td>
                    <%= Html.ActionLink("Details", "Details", new { id = m.Id })%>
                </td>
                <td>
                    <% using (Html.BeginForm("Add", "ShoppingCart", new { bookId = m.Id }))
                       { %>
                    <input type="submit" value="Add" />
                    <% } %>
                </td>
            </div>
        </tr>
        <% } %>
    </table>
</asp:Content>
