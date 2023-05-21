using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookStore.Models;

namespace WebApplication2.Context
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart_Item> Carts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Shoping_Session> shoping_Sessions { get; set; }
        
    }
}