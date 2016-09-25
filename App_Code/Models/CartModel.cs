using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {

        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            db.Carts.Add(cart);
            db.SaveChanges();

            return cart.DatePurchased + "Was successfully inserted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public String UpdateCart(int Id, Cart cart)
    {
        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            Cart p = db.Carts.Find(Id);
            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.ProductID = cart.ProductID;
            p.IsInCart = cart.IsInCart;
            db.SaveChanges();

            return cart.DatePurchased + "Was successfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeletCart(int Id)
    {

        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            Cart cart = db.Carts.Find(Id);
            db.Carts.Attach(cart);
            db.Carts.Remove(cart);
            db.SaveChanges();

            return cart.DatePurchased + "Was successfully deleted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }


    public List<Cart> GetOrdersInCart(string userID)
    {
        ShopDBEntities4 db = new ShopDBEntities4();
        List<Cart> orders = (from x in db.Carts where x.ClientID == userID 
                                 && x.IsInCart orderby x.DatePurchased 
                                 select x).ToList();

        return orders;
    
    }
    public int GetAmountOfOrders(string userID)
    {
        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            int amount = (from x in db.Carts where x.ClientID == userID
                              && x.IsInCart select x.Amount).Sum();

            return amount;

        }
        catch
        {
            return 0;

        }
            

    }

    public void UpdateQuantity(int id, int quantity)
    {
        ShopDBEntities4 db = new ShopDBEntities4();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;

        db.SaveChanges();
    }

    public void MarkOrderAsPaid(List<Cart> carts)
    {

        ShopDBEntities4 db = new ShopDBEntities4();

        if (carts != null)
        {
            foreach (Cart cart in carts)
            {
                Cart oldcart = db.Carts.Find(cart.ID);
                oldcart.DatePurchased = DateTime.Now;
                oldcart.IsInCart = false;
            }
            db.SaveChanges();
        }
    }
}