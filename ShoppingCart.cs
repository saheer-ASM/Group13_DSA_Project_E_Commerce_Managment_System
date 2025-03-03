using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    
    public class ShoppingCart
    {
        
        private class CartNode
        {
            public ShoppingCartItem Data;
            public CartNode Next;
        }

        private CartNode head;

       
        public void AddItem(ShoppingCartItem item)
        {
            CartNode current = head;
            while (current != null)
            {
                if (current.Data.Product.Id == item.Product.Id)
                {
                    current.Data.Quantity += item.Quantity;
                    return;
                }
                current = current.Next;
            }
            
            head = new CartNode { Data = item, Next = head };
        }

        public List<ShoppingCartItem> GetAllItems()
        {
            List<ShoppingCartItem> list = new List<ShoppingCartItem>();
            CartNode current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }

        
        public void Clear() => head = null;
    }
}
