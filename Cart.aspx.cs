using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Context;

namespace WebApplication2
{
    public partial class Cart : System.Web.UI.Page
    {
        protected readonly ApplicationContext context = new ApplicationContext();
        int discount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser loggedInUser = (LoggedInUser)Session["LoggedInUser"];
            if(loggedInUser == null)
            {
                ToastrNotifications toastrNotifications = new ToastrNotifications("Please Log in First", "error");
                Session["Message"] = toastrNotifications;
                Response.Redirect(nameof(Home));
            }
            List<Cart_Item> cart_Items = context.Carts.Where(x => x.Sessionid == loggedInUser.Id).ToList();
            Shoping_Session shoping = context.shoping_Sessions.Where(x => x.UsersId == loggedInUser.Id).FirstOrDefault();
            List<Book> books = new List<Book>();
            foreach(Cart_Item item in cart_Items)
            {
                books.Add(context.Books.Where(x => x.Id == item.BooksId).FirstOrDefault());
            }
            Repeater1.DataSource = books;
            Repeater1.DataBind();
            txt_Shipping.Text = "$10";
            txt_Tax.Text = "$" + (Double.Parse(shoping.Total.ToString())*0.16).ToString();
            double sum = Double.Parse(shoping.Total.ToString()) + 10 + (Double.Parse(shoping.Total.ToString()) * 0.16) - discount;
            txt_Total.Text = "$" + sum;

        }


        protected void Promo_Click(object sender, EventArgs e)
        {
            LoggedInUser loggedInUser = (LoggedInUser)Session["LoggedInUser"];

            Shoping_Session shoping = context.shoping_Sessions.Where(x => x.UsersId == loggedInUser.Id).FirstOrDefault();

            if (txt_Promo.Text.ToLower().Equals("helloworld"))
            {
                discount = 10;
                txt_Discount.Text= "$"+discount.ToString();
                double sum = Double.Parse(shoping.Total.ToString()) + 10 + (Double.Parse(shoping.Total.ToString()) * 0.16) - discount;
                txt_Total.Text = "$" + sum;
            }
        }
    }
}