using Assignment_5.DataAccess;
using Assignment_5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_5.Repositories
{
    public class ItemRepository
    {
        StoreContext context = new StoreContext();


        public IEnumerable<StockItem> GetAllItems()
        {
            return context.Items;
        }

        public StockItem GetItemByID(int? ID)
        {
            if (ID == null) {
                return null;
            }
            return context.Items.FirstOrDefault(item => item.ArticleNumber == ID);
        }

        public IEnumerable<StockItem> GetItemsByID(int? ID)
        {
            if (ID == null)
            {
                return null;
            }
            return context.Items.Where(item => item.ArticleNumber == ID);
        }
        public void Create(StockItem item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }
        public void Edit(StockItem item) {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(StockItem item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }


        public IEnumerable<StockItem> GetItemByNameOrPrice(string Name)
        {
            return context.Items.Where(item=>item.Name.Contains(Name) || item.Price.ToString().Contains(Name));
        }
    }
}