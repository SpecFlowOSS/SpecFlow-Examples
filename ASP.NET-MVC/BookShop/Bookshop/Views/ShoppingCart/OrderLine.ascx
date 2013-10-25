<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<BookShop.Models.OrderLine>" %>

    <fieldset>
        <legend>Book</legend>
        
        <div class="display-label">Title</div>
        <div class="display-field"><%= Html.Encode(Model.Book.Title) %></div>

        <div class="display-label">Price</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.Price)) %></div>
        
        <% using (Html.BeginForm("Edit", "ShoppingCart", new { bookId = Model.Book.Id }))
           {%>
            <div class="display-label">Quantity</div>
            <div class="display-field"><%= Html.TextBoxFor(m => m.Quantity) %>
                <%= Html.ValidationMessageFor(m => m.Quantity)%>
                <input type="submit" value="Update" />
            </div>
        <% } %>
        
         <%= Html.ActionLink("Remove", "DeleteItem", "ShoppingCart", new { Model.Book.Id }, null)%>
        
        
    </fieldset>


