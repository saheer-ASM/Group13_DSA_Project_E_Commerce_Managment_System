using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    // A simple linked list–based shopping cart.
    public class ShoppingCart
    {
        // Internal node class for the linked list.
        private class CartNode
        {
            public ShoppingCartItem Data;
            public CartNode Next;
        }

        private CartNode head;

        // Adds an item to the cart. If the item already exists, increase its quantity.
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
            // Insert new node at the beginning.
            head = new CartNode { Data = item, Next = head };
        }

        // Retrieves all cart items as a List.
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

        // Clears the cart.
        public void Clear() => head = null;
    }
}
