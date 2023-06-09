﻿using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Context;

namespace WebApplication2
{
    public partial class Users : System.Web.UI.Page
    {
        protected readonly ApplicationContext context = new ApplicationContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Lock_Click(object sender, EventArgs e)
        {
            Button Lock = sender as Button;
            int row = int.Parse(Lock.ClientID.Split('_')[3]);
            int id = int.Parse(UserGrid.Rows[row].Cells[0].Text);
            context.Users.Where(u => u.Id == id).ToList().ForEach(u => u.Active = SD.Locked);
            context.SaveChanges();
            Response.Redirect(nameof(Users));
        }

        protected void Unlock_Click(object sender, EventArgs e)
        {
            Button Unlock = sender as Button;
            int row = int.Parse(Unlock.ClientID.Split('_')[3]);
            int id = int.Parse(UserGrid.Rows[row].Cells[0].Text);
            context.Users.Where(x => x.Id == id).ToList().ForEach(u => u.Active = SD.UnLocked);
            context.SaveChanges();
            Response.Redirect(nameof(Users));
        }

        protected void UserGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button Lock = (Button)(e.Row.FindControl("Lock"));
                Button UnLock = (Button)(e.Row.FindControl("Unlock"));
                if (e.Row.Cells[7].Text == SD.UnLocked)
                {
                    UnLock.Visible = false;
                }
                else
                {
                    Lock.Visible = false;
                }
            }

        }
    }
}