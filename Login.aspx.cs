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
    public partial class Login : System.Web.UI.Page
    {
        protected readonly ApplicationContext context = new ApplicationContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = context.Users.Where(x => x.Email == TextBox1.Text && x.password == TextBox2.Text).FirstOrDefault();
            if (user != null)
            {
                if (user.Active == SD.UnLocked)
                {
                    LoggedInUser loggedInUser = new LoggedInUser();
                    loggedInUser.UserName = user.Name;
                    loggedInUser.Id = user.Id;
                    loggedInUser.Email = user.Email;
                    loggedInUser.CartId = user.Id.ToString();
                    loggedInUser.Address = user.Address;
                    loggedInUser.Role = user.Role;
                    loggedInUser.phoneNumber = user.PhoneNumber;
                    Session.Add("LoggedInUser", loggedInUser);
                    ToastrNotifications toastrNotifications = new ToastrNotifications("Logged In successfull!", "success");
                    Session.Add("Message", toastrNotifications);
                    Response.Redirect(nameof(Home));
                }
                else
                {
                    ToastrNotifications notifications = new ToastrNotifications();
                    notifications.Message = " Your Account is Currnetly Locked, Please Contact the support System for more Details ";
                    notifications.Type = "error";
                    Session.Add("Message", notifications);
                }
            }
            else
            {
                ToastrNotifications notifications2 = new ToastrNotifications();
                notifications2.Message = " Your Email or Password is incorect " +
                                                    " Please Try again ! ";
                notifications2.Type = "error";
                Session.Add("Message", notifications2);
            }

        }
    }
}