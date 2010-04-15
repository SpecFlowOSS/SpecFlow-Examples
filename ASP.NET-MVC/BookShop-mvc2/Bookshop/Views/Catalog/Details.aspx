<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Bookshop.Models.Book>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            Id</div>
        <div class="display-field">
            <%= Html.Encode(Model.Id) %></div>
        <div class="display-label">
            Author</div>
        <div class="display-field">
            <%= Html.Encode(Model.Author) %></div>
        <div class="display-label">
            Title</div>
        <div class="display-field">
            <%= Html.Encode(Model.Title) %></div>
        <div class="display-label">
            Price</div>
        <div class="display-field">
            <%= Html.Encode(String.Format("{0:F}", Model.Price)) %></div>
    </fieldset>
    <p>
        <% using (Html.BeginForm("Add", "ShoppingCart", new { bookId = Model.Id }))
           { %>
        <input type="submit" value="Add to cart" />
        <% } %>
    </p>
</asp:Content>
