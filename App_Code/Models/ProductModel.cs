using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    
    public string InsertProduct(Product product) 
    {
        
        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            db.Products.Add(product);
            db.SaveChanges();

            return product.Name + "Was successfully inserted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public String UpdateProduct(int Id, Product product)
    {
        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            Product p = db.Products.Find(Id);
            p.Name = product.Name;
            p.Price = product.Price;
            p.ProductTypes1 = product.ProductTypes1;
            p.TypeId = product.TypeId;
            p.Description = product.Description;
            p.Image = product.Image;
            db.SaveChanges();

            return product.Name + "Was successfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeletProduct(int Id)
    {

        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            Product product = db.Products.Find(Id);
            db.Products.Attach(product);
            db.Products.Remove(product);
            db.SaveChanges();

            return product.Name + "Was successfully deleted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            using (ShopDBEntities4 db = new ShopDBEntities4())
            {
                Product product = db.Products.Find(id);
                return product;
            }
        }
        catch (Exception)
        {
            return  null;
        }
         
    }

    public List<Product> GetAllProducts()
    {
        try
        {
             using (ShopDBEntities4 db = new ShopDBEntities4())
            {
                List<Product> products = (from x in db.Products select x).ToList();
                return products;
            }

        }
        catch (Exception)
        { 
            return null;
        }
    }

    public List<Product> GetProductsByType(int typeID)
    {
        try
        {
            using (ShopDBEntities4 db = new ShopDBEntities4())
            {
                List<Product> products = (from x in db.Products where x.TypeId == typeID select x).ToList();
                return products;
            }

        }
        catch (Exception)
        {
            return null;
        }
    }
}