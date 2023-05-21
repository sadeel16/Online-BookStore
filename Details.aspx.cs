using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Context;

namespace WebApplication2
{
    public partial class Details : System.Web.UI.Page
    {
        protected readonly ApplicationContext context = new ApplicationContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] == null)
            {
                ToastrNotifications toastr = new ToastrNotifications("Please Login First", "error");
                Session["Message"] = toastr;

                Response.Redirect(nameof(Home));
            }
            if (Request.Params["id"] == null)
            {
                Response.Redirect(nameof(Home));
            }
            int value = int.Parse(Request.Params["id"]);
            List<Book> book = context.Books.Where(x => x.Id == value).ToList();
            txtAuthor.Text = book[0].Author;
            txtDescription.Text = book[0].Description;
            txtISBN.Text = book[0].Id.ToString();
            txtName.Text = book[0].Title;
            txtPrice.Text = book[0].Price.ToString() + "$";
            if (book[0].Status.Equals(SD.notAvailable))
            {
                btnCart.Visible = false;
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(nameof(Home));
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            int bookStock = Int32.Parse(txtCount.Text);
            Shoping_Session shop = new Shoping_Session();
            int value = int.Parse(Request.Params["id"]);
            Book book = context.Books.Where(x => x.Id == value).FirstOrDefault();
            if(bookStock > book.Quantity)
            {
                ToastrNotifications toastrNotifications = new ToastrNotifications("Please Select a lower Quantity !", "error");
                Session["Message"] = toastrNotifications;
                Response.Redirect("Details?id="+value);
            }
            LoggedInUser user = (LoggedInUser)Session["LoggedInUser"];

            try
            {
                Shoping_Session Cart = context.shoping_Sessions.Where(x => x.UsersId == user.Id).FirstOrDefault();
                if (Cart != null)
                {
                    //update

                    Cart.UpdatedDate = DateTime.Now;
                    Cart.Total += decimal.Parse(book.Price.ToString());
                    context.SaveChanges();

                }
                else
                {
                    //create
                    Cart = new Shoping_Session();
                    Cart.CreatedDate = DateTime.Now;
                    Cart.Total = decimal.Parse(book.Price.ToString());
                    Cart.UsersId = user.Id;
                    Cart.UpdatedDate = DateTime.Now;
                    context.shoping_Sessions.Add(Cart)
;
                    context.SaveChanges();
                }

                book.Quantity = book.Quantity - 1;
                if(book.Quantity == 0)
                {
                    book.Status = SD.notAvailable;
                }
                context.SaveChanges();

                ToastrNotifications notifications = new ToastrNotifications("Successfully Added to Cart", "success");
                Session["Message"] = notifications;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            cart_item();


        }

        protected void cart_item()
        {
            LoggedInUser user = (LoggedInUser)Session["LoggedInUser"];
            Cart_Item item = new Cart_Item();
            item.Sessionid = user.Id;
            item.BooksId = int.Parse(Request.Params["id"]);
            context.Carts.Add(item);
            context.SaveChanges();


        }
    }
}