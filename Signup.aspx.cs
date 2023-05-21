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
    public partial class Signup : System.Web.UI.Page
    {
        protected readonly ApplicationContext dbcontext = new ApplicationContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_btn_Click(object sender, EventArgs e)
        {
            if (IsvalidUser(email_txt.Text))
            {
                User user = new User();
                user.Email = email_txt.Text;
                user.Name = name_txt.Text;
                user.Address = address_txt.Text;
                user.PhoneNumber = phoneNumber_txt.Text;
                user.password = password_txt.Text;
                user.Role = SD.Customer;
                user.Active = SD.UnLocked;

                try
                {
                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();

                    ToastrNotifications toastr = new ToastrNotifications("Entery was Successfull", "success");
                    Session["Message"] = toastr;
                }
                catch (Exception)
                {

                    throw;
                }
                name_txt.Text = String.Empty;
                email_txt.Text = String.Empty;
                address_txt.Text = String.Empty;
                phoneNumber_txt.Text = String.Empty;
                password_txt.Text = String.Empty;
                Response.Redirect(nameof(Login));

            }
            else
            {
                name_txt.Text = String.Empty;
                email_txt.Text = String.Empty;
                address_txt.Text = String.Empty;
                phoneNumber_txt.Text = String.Empty;
                password_txt.Text = String.Empty;
                ToastrNotifications toastr = new ToastrNotifications("Email Already Exits", "error");
                Session["Message"] = toastr;
            }
        }

        private bool IsvalidUser(string text)
        {
            BookStore.Models.User user = dbcontext.Users.Where(x => x.Email == text).FirstOrDefault();
            return user == null;
        }
    }
}