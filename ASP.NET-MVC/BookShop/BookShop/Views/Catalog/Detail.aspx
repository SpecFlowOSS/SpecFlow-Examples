<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BookShop.Models.Book> " %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Book Details:</h2>

    <b>Title:</b> <%= ViewData.Model.Title%>
    <br />
    <b>Author:</b> <%= ViewData.Model.Author%>   
    <br />
    <b>Price:</b> <%= ViewData.Model.Price%>
</asp:Content>
