<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage<IList<BookShop.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Best offers</h3>
    <table>
        <tr>
            <th>Book</th>
            <th>Price</th>
        </tr>
        <% foreach (var m in ViewData.Model  ) { %>
        <tr>
            <div class="item">
                <td class="title">
                    <%= Html.ActionLink(m.Author + ": " + m.Title, "Details", "Catalog", new { id = m.Id }, null)%>
                </td>
                <td class="price">
                    <%= Html.Encode(String.Format("{0:F}", m.Price)) %>
                </td>
            </div>
        </tr>
        <% } %>
    </table>
    

</asp:Content>
