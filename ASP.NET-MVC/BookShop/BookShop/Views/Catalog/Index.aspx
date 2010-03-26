<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<BookShop.Models.Book>> " %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
        <% using (Html.BeginForm("List", "Catalog", System.Web.Mvc.FormMethod.Get))
           { %>
        <div class="row">
        <b>Search:</b>
            <%= Html.TextBox("searchTerm")%>
            <input type="submit" class="right" id="searchButton" value="Go!" />
        </div>        
        <% } %>
</asp:Content>
