using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get all books in the catalog.
            List<Book> books = BookCatalogDataAccess.GetAllBooks();
            foreach (Book book in books)
            {
                //todo: Populate dropdown list selections 
                ListItem title = new ListItem(book.Title,book.Id);
                drpBookSelection.Items.Add(title);
            }
        }
        ShoppingCart shoppingcart = null;
        if (Session["shoppingcart"] == null)
        {
            //todo: add cart to the session
            shoppingcart = new ShoppingCart();
            Session["shoppingcart"] = shoppingcart;
        }
        else
        {
            //todo: retrieve cart from the session
            shoppingcart = Session["shoppingcart"] as ShoppingCart;

            foreach(BookOrder order in shoppingcart.BookOrders)
            {
                //todo: Remove the book in the order from the dropdown list
                string book = order.Book.Id;
                ListItem removeBook = drpBookSelection.Items.FindByValue(book);
                drpBookSelection.Items.Remove(removeBook);
            }
        }

        if (shoppingcart.NumOfItems == 0)
            lblNumItems.Text = "empty";
        else if (shoppingcart.NumOfItems == 1)
            lblNumItems.Text = "1 item";
        else
            lblNumItems.Text = shoppingcart.NumOfItems.ToString() + " items";
        
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpBookSelection.SelectedValue != "-1")
        {
            string bookId = drpBookSelection.SelectedItem.Value;
            Book selectedBook = BookCatalogDataAccess.GetBookById(bookId);

            //todo: Add selected book to the session
            List<Book> books = Session["books"] as List<Book>;
            if (books == null)
            {
                books = new List<Book>();
                Session["books"] = books;
            }

            books.Add(selectedBook);
            
            //todo: Display the selected book's description and price 
            lblDescription.Text = selectedBook.Description;
            lblPrice.Text = "$" + selectedBook.Price.ToString();
        }
        else
        {
            //todo: Set description and price to blank
            lblDescription.Text = "";
            lblPrice.Text = "";
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (drpBookSelection.SelectedValue != "-1" && Session["shoppingcart"] != null)
        {

            string bookId = drpBookSelection.SelectedItem.Value;
            Book selectedBook = BookCatalogDataAccess.GetBookById(bookId);

            //todo: Retrieve selected book from the session
            //Book book = Session["book"] as Book;
            //todo: get user entered quqntity
            int quantity = int.Parse(txtQuantity.Text);
            //todo: Create a book order with selected book and quantity
            BookOrder order = new BookOrder(selectedBook, quantity);
            //todo: Retrieve to cart from the session
            ShoppingCart cart = Session["shoppingcart"] as ShoppingCart;
            //todo: Add book order to the shopping cart
            cart.AddBookOrder(order);
            //todo: Remove the selected item from the dropdown list
            drpBookSelection.Items.Remove(drpBookSelection.SelectedItem);
            //todo: Set the dropdown list's selected value as "-1"
            //drpBookSelection.SelectedValue = "-1";
            //todo: Set the description to show title and quantity of the book user added to the shopping cart
            lblDescription.Text = quantity.ToString() + " copy(s) of " + selectedBook.Title + " is added to the shopping cart";
            //todo: Update the number of items in shopping cart displayed next to the link to ShoppingCartView.aspx
            if (cart.NumOfItems == 0)
                lblNumItems.Text = "empty";
            else if (cart.NumOfItems == 1)
                lblNumItems.Text = "1 item";
            else
                lblNumItems.Text = cart.NumOfItems.ToString() + " items";
        }
    }
}