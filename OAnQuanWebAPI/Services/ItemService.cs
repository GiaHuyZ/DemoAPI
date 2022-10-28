using Microsoft.AspNetCore.Mvc;
using OAnQuanWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAnQuanWebAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly OAnQuanGameContext _context;

        public ItemService(OAnQuanGameContext context)
        {
            _context = context;
        }

        public Item CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }
        public List<Item> GetAllItem()
        {
            var itemList = _context.Items.Select(i => new Item
            {
                Id = i.Id,
                ItemName = i.ItemName,
                ItemDescription = i.ItemDescription,
                Price = i.Price,
                TypeId = i.TypeId,
            });
            return itemList.ToList();
        }

        public Item GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void Updateitem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
