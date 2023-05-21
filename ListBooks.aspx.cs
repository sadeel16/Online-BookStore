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
    public partial class ListBooks : System.Web.UI.Page
    {
        protected readonly ApplicationContext context = new ApplicationContext();
        int RowChanged = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.DeleteCommand = "DELETE from Books where Id=@Id";
            SqlDataSource1.UpdateCommand = "UPDATE Books SET Title=@Title,Author = @Author,Description= @Description,Quantity = @Quantity,Status = @Status, Price = @Price where Id = @Id";

        }

        protected void BookGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            int id = Int32.Parse( BookGrid.Rows[RowChanged].Cells[0].Text);
            Book book = context.Books.Where(x => x.Id == id).FirstOrDefault();
            if(book.Quantity > 0)
            {
                book.Status = SD.available;
            }
            context.SaveChanges();
        }

        protected void BookGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RowChanged = e.RowIndex;
        }
    }
}