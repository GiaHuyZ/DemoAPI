using OAnQuanWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAnQuanWebAPI.Services
{
    public interface IItemService
    {
        List<Item> GetAllItem();
        Item GetItemById(int id);
        Item CreateItem(Item item);
        void Updateitem(Item item);
        void DeleteItem(int id);

    }
}
