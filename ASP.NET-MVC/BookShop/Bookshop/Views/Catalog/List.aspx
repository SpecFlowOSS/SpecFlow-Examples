<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Bookshop.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Book List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th colspan="2"></th>
        </tr>
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
                           <a onclick='$(this).closest("form").submit()' href="JavaScript:void(0)">Add to cart</a>
                    <% } %>
                </td>
            </div>
        </tr>
        <% } %>
    </table>
</asp:Content>
