using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeModel
/// </summary>
public class ProductTypeModel
{
    public string InsertProductType(ProductTypes1 productTypes1)
    {

        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            db.ProductTypes1.Add(productTypes1);
            db.SaveChanges();

            return productTypes1.Name + "Was successfully inserted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public String UpdateProductType(int Id, ProductTypes1 productTypes1)
    {
        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            ProductTypes1 p = db.ProductTypes1.Find(Id);
            p.Name = productTypes1.Name;

            db.SaveChanges();

            return productTypes1.Name + "Was successfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeletProductType(int Id)
    {

        try
        {
            ShopDBEntities4 db = new ShopDBEntities4();
            ProductTypes1 productType = db.ProductTypes1.Find(Id);
            db.ProductTypes1.Attach(productType);
            db.ProductTypes1.Remove(productType);
            db.SaveChanges();

            return productType.Name + "Was successfully deleted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public ProductTypes1 GetProductTypes1(int id)
    {
        try
        {
            using (ShopDBEntities4 db = new ShopDBEntities4())
            {
                ProductTypes1 productTypes1 = db.ProductTypes1.Find(id);
                return productTypes1;
            }
        }
        catch (Exception)
        {
            return null;
        }

    }
}